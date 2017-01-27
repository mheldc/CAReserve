Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Management
Imports System.Net.Mail
Imports System.Configuration

Namespace HRISLibrary
    Public Module Declares
        'Public HashKeyCode, SaltKeyCode As String
        Public HashKeyCode As String = "The quick brown fox jumps over the lazy dog."
        Public SaltKeyCode As String = ".god yzal eht revo spmuj xof nworb kciuq ehT"

        ' Database General Variables
        Public CnString As String = "Server=localhost;Database=careserve;uid=root;pwd=;",
               CmdParameterList As ArrayList = Nothing,
               CmdString As String = "",
               DefaultDbType As PreferedDbType = PreferedDbType.DB_NONE

        ' Mail Service Variables
        Public ClientCertificates As String = "", _
               Credentials As String = "", _
               EnableSSL As Boolean = False, _
               Host As String = "127.0.0.1", _
               Port As Integer = 587, _
               TimeOut As Integer = 0, _
               UseDefaultCredentials As Boolean = False

        ' Other General Variable-Type-Enums
        Public OptionType As OptionTypes = OptionTypes.None

        ' User information variables
        Public UserHandleId As Long = 0, _
               UserHandleName As String = "Default User", _
               UserCompanyId As Int64 = 1, _
               UserRoleId As Integer = 0, _
               UserRoleDesc As String = "Default Role"

        ' Other/User Defined variables
        Public ResultsCatcher As Object

        Public Enum PreferedDbType As Integer
            DB_NONE = -1
            DB_MSSQL = 0
            DB_MYSQL = 1
            DB_ORACLE = 2
        End Enum

        Public Enum OptionTypes As Integer
            None = -1
            Country = 0
            Region = 1
            Province = 2
            City = 3
        End Enum

        Public Enum DataEventType As Integer
            None = -1
            Insert = 0
            Update = 1
            Delete = 2
            Purge = 3
            SearchNLoad = 4
            Print = 5
        End Enum

        Public Enum SearchType As Integer
            None = -1
            GetList = 0
            GetInformation = 1
        End Enum

    End Module

    Public NotInheritable Class Cryptography

        '  1. Create the Simple3Des class to encapsulate the encryption and decryption methods.
        '  2. Add an import of the cryptography namespace to the start of the file that contains the Simple3Des class.
        '  3. In the Simple3Des class, add a private field to store the 3DES cryptographic service provider. 
        '  4. Add a private method that creates a byte array of a specified length from the hash of the specified key.
        '  5. Add a constructor to initialize the 3DES cryptographic service provider.
        '       The key parameter controls the EncryptData and DecryptData methods.
        '  6. Add a public method that encrypts a string.
        '  7. Add a public method that decrypts a string. 

        Private TripleDES As New TripleDESCryptoServiceProvider

        Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()

            Dim SHA1 As New SHA1CryptoServiceProvider

            ' Hash the key. 
            Dim KeyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
            Dim Hash() As Byte = SHA1.ComputeHash(KeyBytes)

            ' Truncate or pad the hash. 
            ReDim Preserve Hash(length - 1)
            Return Hash

        End Function

        Sub New()
            ' Initialize the crypto provider.
            TripleDES.Key = TruncateHash(Declares.HashKeyCode, TripleDES.KeySize \ 8)
            TripleDES.IV = TruncateHash(Declares.SaltKeyCode, TripleDES.BlockSize \ 8)
        End Sub

        Public Function EncryptData(ByVal plaintext As String) As String

            ' Convert the plaintext string to a byte array. 
            Dim plaintextBytes() As Byte =
                System.Text.Encoding.Unicode.GetBytes(plaintext)

            ' Create the stream. 
            Dim ms As New System.IO.MemoryStream
            ' Create the encoder to write to the stream. 
            Dim encStream As New CryptoStream(ms,
                TripleDES.CreateEncryptor(),
                System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
            encStream.FlushFinalBlock()

            ' Convert the encrypted stream to a printable string. 
            Return Convert.ToBase64String(ms.ToArray)
        End Function

        Public Function DecryptData(ByVal encryptedtext As String) As String

            ' Convert the encrypted text string to a byte array. 
            Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

            ' Create the stream. 
            Dim ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream. 
            Dim decStream As New CryptoStream(ms,
                TripleDES.CreateDecryptor(),
                System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
            decStream.FlushFinalBlock()

            ' Convert the plaintext stream to a string. 
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
        End Function

    End Class

    Public Class Database
        ''' <summary>
        ''' Opens a connection between application and supported databases. 
        ''' </summary>
        ''' <param name="ConnectionString">(String) Connection parameter. See database documentation for reference.</param>
        ''' <param name="DbType">(Database Type) Supported database includes MSSQL, MYSQL and Oracle(soon).</param>
        ''' <returns>(Object) Connection object.</returns>
        ''' <remarks>Created by Romel S. Dela Cruz on May 25, 2016</remarks>
        Public Shared Function Open(ByVal ConnectionString As String, ByVal DbType As PreferedDbType) As Object
            Dim tmpCn As New Object
            Try
                Select Case DbType
                    Case PreferedDbType.DB_MSSQL
                        tmpCn = New SqlConnection(ConnectionString)
                        DirectCast(tmpCn, SqlConnection).Open()

                    Case PreferedDbType.DB_MYSQL
                        tmpCn = New MySqlConnection(ConnectionString)
                        DirectCast(tmpCn, MySqlConnection).Open()
                    Case PreferedDbType.DB_ORACLE
                        ' Soon to be implemented

                    Case Else
                        tmpCn = New SqlConnection(ConnectionString)
                        DirectCast(tmpCn, SqlConnection).Open()
                End Select

            Catch ex As Exception
                MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "Server Connection Failed")
            End Try
            Return tmpCn
        End Function

        ''' <summary>
        ''' Opens a connection between application and supported databases. 
        ''' </summary>
        ''' <param name="ServerHost">(String) Database server hostname or IP address.</param>
        ''' <param name="DefaultDatabase">(String) Database name. </param>
        ''' <param name="UserId">(String) Server Login Id.</param>
        ''' <param name="Password">(String) Server Login Password.</param>
        ''' <param name="DbType">(Database Type) Supported database includes MSSQL, MYSQL and Oracle(soon).</param>
        ''' <param name="DefaultPort">(Integer) Port used for the connection.</param>
        ''' <param name="TrustedConnection">(Boolean) Use secured connection.</param>
        ''' <returns>(Object) Connection object.</returns>
        ''' <remarks>Created by Romel S. Dela Cruz on May 25, 2016</remarks>
        Public Shared Function Open(ByVal ServerHost As String, ByVal DefaultDatabase As String, ByVal UserId As String, ByVal Password As String, DbType As PreferedDbType, _
                                    Optional ByVal DefaultPort As Integer = 0, Optional ByVal TrustedConnection As Boolean = False) As Object

            Dim tmpCn As New Object, ConnectionString As String = ""

            If TrustedConnection = False Then
                Select Case DbType
                    Case PreferedDbType.DB_MSSQL
                        ConnectionString = "Server=[1];Database=[2];User Id=[3];Password=[4];"
                    Case PreferedDbType.DB_MYSQL
                        ConnectionString = "Server=[1];Database=[2];Uid=[3];Pwd=[4];Port=[5];"
                        If DefaultPort = 0 Then DefaultPort = 3306
                    Case PreferedDbType.DB_ORACLE
                        ConnectionString = "Data Source=[2];User Id=[3];Password=[4];Integrated Security=no;"
                    Case Else

                End Select
            Else
                Select Case DbType
                    Case PreferedDbType.DB_MSSQL
                        ConnectionString = "Server=[1];Database=[2];Trusted_Connection=True;"
                    Case PreferedDbType.DB_MYSQL
                        ConnectionString = "Server=[1];Database=[2];Uid=[3];Pwd=[4];SslMode=Preferred;"
                    Case PreferedDbType.DB_ORACLE
                        ConnectionString = "Data Source=[2];Integrated Security=yes;"
                    Case Else

                End Select
            End If

            ConnectionString = ConnectionString.Replace("[1]", ServerHost).Replace("[2]", DefaultDatabase).Replace("[3]", UserId).Replace("[4]", Password).Replace("[5]", DefaultPort)

            Try
                Select Case DbType
                    Case PreferedDbType.DB_MSSQL
                        tmpCn = New SqlConnection(ConnectionString)
                        DirectCast(tmpCn, SqlConnection).Open()
                    Case PreferedDbType.DB_MYSQL
                        tmpCn = New MySqlConnection(ConnectionString)
                        DirectCast(tmpCn, MySqlConnection).Open()
                    Case PreferedDbType.DB_ORACLE
                        ' Soon to be implemented

                    Case Else
                        tmpCn = New SqlConnection(ConnectionString)
                        DirectCast(tmpCn, SqlConnection).Open()
                End Select

            Catch ex As Exception
                MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "Server Connection Failed")
            End Try
            Return tmpCn
        End Function

        ''' <summary>
        ''' Command query execution.
        ''' </summary>
        ''' <param name="UsedConnection">(Connection Object) Currently used active connection object.</param>
        ''' <param name="DbType">(Database Types) Supported database includes MSSQL, MYSQL and Oracle(soon).</param>
        ''' <param name="CommandString">(String) Query statement(s) to be executed/processed.</param>
        ''' <param name="CommandParameters">(Array) Set of connection parameters.</param>
        ''' <param name="CommandTypes">(Object) Command / Query type.</param>
        ''' <returns>Datatable</returns>
        ''' <remarks>Created by Romel S. Dela Cruz on June 4, 2016</remarks>
        Public Shared Function ExecuteCommand(ByVal UsedConnection As Object, ByVal DbType As PreferedDbType, ByVal CommandString As String, Optional CommandParameters As ArrayList = Nothing, Optional CommandTypes As CommandType = CommandType.Text) As Integer
            Dim AffectedRecords As Integer = 0
            Try
                Select Case DbType
                    Case PreferedDbType.DB_MSSQL
                        Using Cm As New SqlCommand(CommandString, UsedConnection)
                            Cm.CommandType = CommandTypes
                            If IsNothing(CommandParameters) = False Then
                                For iParams As Integer = 0 To CommandParameters.Count - 1 Step 1
                                    Cm.CreateParameter()
                                    With Cm
                                        .Parameters.Add(CommandParameters(iParams))
                                    End With
                                Next
                            End If

                            AffectedRecords = Cm.ExecuteNonQuery()

                        End Using
                    Case PreferedDbType.DB_MYSQL
                        Using Cm As New MySqlCommand(CommandString, UsedConnection)
                            Cm.CommandType = CommandTypes
                            If IsNothing(CommandParameters) = False Then
                                For iParams As Integer = 0 To CommandParameters.Count - 1 Step 1
                                    Cm.CreateParameter()
                                    With Cm
                                        .Parameters.Add(CommandParameters(iParams))
                                    End With
                                Next
                            End If
                            AffectedRecords = Cm.ExecuteNonQuery()
                        End Using
                    Case PreferedDbType.DB_ORACLE
                    Case Else
                        ' Nothing to do here.
                End Select
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

            Return AffectedRecords

        End Function


        ''' <summary>
        ''' Query statement execution object.
        ''' </summary>
        ''' <param name="UsedConnection">(Connection Object) Currently used active connection object.</param>
        ''' <param name="CommandString">(String) Query statement(s) to be executed/processed.</param>
        ''' <param name="DbType">(Database Type) Supported database includes MSSQL, MYSQL and Oracle(soon).</param>
        ''' <param name="CommandParameters">(Array) Set of connection parameters.</param>
        ''' <param name="CommandTypes">(Object) Command / Query type.</param>
        ''' <returns>Datatable</returns>
        ''' <remarks>Created by Romel S. Dela Cruz on May 25, 2016</remarks>
        Public Shared Function GetResults(ByVal UsedConnection As Object, ByVal CommandString As String, ByVal DbType As PreferedDbType, Optional ByVal CommandParameters As ArrayList = Nothing, Optional CommandTypes As CommandType = CommandType.Text) As DataTable
            Dim tmpDT As New DataTable

            Try
                Select Case DbType
                    Case PreferedDbType.DB_MSSQL
                        Using Cm As New SqlCommand(CommandString, DirectCast(UsedConnection, SqlConnection))
                            If IsNothing(CommandParameters) = False Then
                                Cm.CreateParameter()
                                For iParams As Integer = 0 To CommandParameters.Count - 1 Step 1
                                    Cm.Parameters.Add(CommandParameters(iParams))
                                Next
                            End If

                            Using Da As New SqlDataAdapter(Cm)
                                Da.Fill(tmpDT)
                            End Using
                        End Using
                    Case PreferedDbType.DB_MYSQL
                        Using Cm As New MySqlCommand(CommandString, DirectCast(UsedConnection, MySqlConnection))
                            If IsNothing(CommandParameters) = False Then
                                Cm.CreateParameter()
                                For iParams As Integer = 0 To CommandParameters.Count - 1 Step 1
                                    Cm.Parameters.Add(CommandParameters(iParams))
                                Next
                            End If
                            Using Da As New MySqlDataAdapter(Cm)
                                Da.Fill(tmpDT)
                            End Using
                        End Using

                    Case PreferedDbType.DB_ORACLE
                    Case Else

                End Select

            Catch ex As Exception
                MsgBox("Error acquiring results due to : " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

            Return tmpDT
        End Function

        ''' <summary>
        ''' Data loader for Combobox and Listbox
        ''' </summary>
        ''' <param name="UsedConnection">(Connection Object) Currently used active connection object.</param>
        ''' <param name="CommandString">(String) Query statement(s) to be executed/processed.</param>
        ''' <param name="DbType">(Object) Supported database includes MSSQL, MYSQL and Oracle(soon)</param>
        ''' <param name="ControlObject">(Winform Control) Target control where to load data.</param>
        ''' <param name="CommandParameters">(Arraylist) Collection of parameters to be passed to a command. Default NULL.</param>
        ''' <param name="CommandTypes">(CommandType) Command type.</param>
        ''' <remarks>Created by Romel S. Dela Cruz on May 25, 2016</remarks>
        Public Shared Sub LoadDataToControl(ByVal UsedConnection As Object, ByVal CommandString As String, ByVal DbType As PreferedDbType, _
                                            ByRef ControlObject As Control, Optional ByVal CommandParameters As ArrayList = Nothing, _
                                            Optional ByVal CommandTypes As CommandType = CommandType.Text)

            Dim tmpDT As New DataTable

            If TypeOf ControlObject Is ListBox Then
                If DbType = PreferedDbType.DB_MSSQL Then
                    Using Cm As New SqlCommand(CommandString, UsedConnection)
                        If IsNothing(CommandParameters) = False Then
                            Cm.CreateParameter()
                            For iParams As Integer = 0 To CommandParameters.Count - 1 Step 1
                                Cm.Parameters.Add(CommandParameters(iParams))
                            Next
                        End If
                        Using Da As New SqlDataAdapter(Cm)
                            Da.Fill(tmpDT)
                        End Using
                        With DirectCast(ControlObject, ListBox)
                            .DataSource = tmpDT.DefaultView
                            .ValueMember = "valuemember"
                            .DisplayMember = "displaymember"
                        End With
                    End Using
                ElseIf DbType = PreferedDbType.DB_MYSQL Then
                    Using Cm As New MySqlCommand(CommandString, UsedConnection)
                        If IsNothing(CommandParameters) = False Then
                            Cm.CreateParameter()
                            For iParams As Integer = 0 To CommandParameters.Count - 1 Step 1
                                Cm.Parameters.Add(CommandParameters(iParams))
                            Next
                        End If
                        Using Da As New MySqlDataAdapter(Cm)
                            Da.Fill(tmpDT)
                        End Using
                        With DirectCast(ControlObject, ListBox)
                            .DataSource = tmpDT.DefaultView
                            .ValueMember = "valuemember"
                            .DisplayMember = "displaymember"
                        End With
                    End Using
                ElseIf DbType = PreferedDbType.DB_ORACLE Then
                    ' Not yet implemented
                Else
                    MsgBox("Currently does not support this connection object.", MsgBoxStyle.Exclamation, "Error")
                End If

            ElseIf TypeOf ControlObject Is ComboBox Then
                If DbType = PreferedDbType.DB_MSSQL Then
                    Using Cm As New SqlCommand(CommandString, UsedConnection)
                        If IsNothing(CommandParameters) = False Then
                            Cm.CreateParameter()
                            For iParams As Integer = 0 To CommandParameters.Count - 1 Step 1
                                Cm.Parameters.Add(CommandParameters(iParams))
                            Next
                        End If
                        Using Da As New SqlDataAdapter(Cm)
                            Da.Fill(tmpDT)
                            With DirectCast(ControlObject, ComboBox)
                                .DataSource = tmpDT.DefaultView
                                .ValueMember = "valuemember"
                                .DisplayMember = "displaymember"
                            End With
                        End Using
                    End Using
                ElseIf DbType = PreferedDbType.DB_MYSQL Then
                    Using Cm As New MySqlCommand(CommandString, UsedConnection)
                        If IsNothing(CommandParameters) = False Then
                            Cm.CreateParameter()
                            For iParams As Integer = 0 To CommandParameters.Count - 1 Step 1
                                Cm.Parameters.Add(CommandParameters(iParams))
                            Next
                        End If
                        Using Da As New MySqlDataAdapter(Cm)
                            Da.Fill(tmpDT)
                            With DirectCast(ControlObject, ComboBox)
                                .DataSource = tmpDT.DefaultView
                                .ValueMember = "valuemember"
                                .DisplayMember = "displaymember"
                            End With
                        End Using
                    End Using
                ElseIf DbType = PreferedDbType.DB_ORACLE Then
                    ' Not yet implemented
                Else
                    MsgBox("Currently does not support this connection object.", MsgBoxStyle.Exclamation, "Error")
                End If

            Else
                MsgBox("This is some other control")
            End If

        End Sub

        ''' <summary>
        ''' Activity and/or Audit Logging
        ''' </summary>
        ''' <param name="UsedConnection">(Connection Object) Currently used active connection object.</param>
        ''' <param name="DbType">(Object) Supported database includes MSSQL, MYSQL and Oracle(soon).</param>
        ''' <param name="TranType">(Integer) Transaction Types for Audit logs. Possible values : 0- Insert, 1- Retrieve.</param>
        ''' <param name="LogSourceType">(Integer) Log/Activity Source. Possible values : 0- Application, 1- Query Command, 2- Exception.</param>
        ''' <param name="LogSourceDesc">(String) Log Source Description.</param>
        ''' <param name="LogActivity">(String) Activity description or exception message.</param>
        ''' <param name="CurrentUser">(Integer) Current user handle id</param>
        ''' <param name="ReturnValue">(Object) Results handler/storage. </param>
        ''' <remarks>Created by Romel S. Dela Cruz on June 5, 2016</remarks>
        Public Shared Sub LogAudit(ByVal UsedConnection As Object, ByVal DbType As PreferedDbType, ByVal TranType As Integer, _
                                   ByVal LogSourceType As Integer, ByVal LogSourceDesc As String, ByVal LogActivity As String, _
                                   ByVal CurrentUser As Integer, ByRef ReturnValue As Object)

            Select Case DbType
                Case PreferedDbType.DB_MSSQL
                    CmdString = "Exec sp_hrisaudit @ttype, @srctype, @srcdesc, @actdesc, @userid;"
                    Using Cm As New SqlCommand(CmdString, UsedConnection)
                        Cm.CreateParameter()
                        With Cm.Parameters
                            .AddWithValue("@ttype", TranType)
                            .AddWithValue("@srctype", LogSourceType)
                            .AddWithValue("@srcdesc", LogSourceDesc)
                            .AddWithValue("@actdesc", LogActivity)
                            .AddWithValue("@userid", CurrentUser)
                        End With
                        If TranType = 0 Then
                            ReturnValue = Cm.ExecuteNonQuery()
                        Else
                            Dim tmpDT As New DataTable
                            Using Da As New SqlDataAdapter(Cm)
                                Da.Fill(tmpDT)
                                ReturnValue = tmpDT
                            End Using
                        End If
                    End Using
                Case PreferedDbType.DB_MYSQL
                    CmdString = "Call sp_hrisaudit @ttype, @srctype, @srcdesc, @actdesc, @userid;"
                    Using Cm As New MySqlCommand(CmdString, UsedConnection)
                        Cm.CreateParameter()
                        With Cm.Parameters
                            .AddWithValue("@ttype", TranType)
                            .AddWithValue("@srctype", LogSourceType)
                            .AddWithValue("@srcdesc", LogSourceDesc)
                            .AddWithValue("@actdesc", LogActivity)
                            .AddWithValue("@userid", CurrentUser)
                        End With
                        If TranType = 0 Then
                            ReturnValue = Cm.ExecuteNonQuery()
                        Else
                            Dim tmpDT As New DataTable
                            Using Da As New MySqlDataAdapter(Cm)
                                Da.Fill(tmpDT)
                                ReturnValue = tmpDT
                            End Using
                        End If
                    End Using
                Case PreferedDbType.DB_ORACLE
                Case PreferedDbType.DB_NONE
                Case Else
                    'Nothing to do here.
            End Select

        End Sub
    End Class

    Public Class MailerService
        Public Shared Function SendEmailMessage(ByVal Sender As MailAddress, ByVal Recipient As String, ByVal MailSubject As String, _
                                                ByVal MailBody As String, Optional ByVal IsBodyHTML As Boolean = False, _
                                                Optional ByVal CCRecipient As String = "", Optional ByVal BCCRecipient As String = "", _
                                                Optional ByVal MailAttachments As Attachment = Nothing) As Boolean

            Try
                Using MailServer As New SmtpClient
                    With MailServer
                        .UseDefaultCredentials = False
                        .Credentials = New Net.NetworkCredential("msd@ipiphil.com", "tanginamotitinginkapa!")
                        .Port = 587
                        .EnableSsl = True
                        .Host = "smtp.ipiphil.com"
                    End With

                    Using NewMail As New MailMessage()
                        With NewMail
                            .From = Sender
                            .To.Add(Recipient)
                            .CC.Add(CCRecipient)
                            .Bcc.Add(BCCRecipient)
                            .Subject = MailSubject
                            If IsNothing(MailAttachments) = False Then
                                .Attachments.Add(MailAttachments)
                            End If
                            .IsBodyHtml = IsBodyHTML
                            .Body = MailBody
                        End With
                        MailServer.Send(NewMail)

                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Sending Mail")
            End Try
            Return True

        End Function
    End Class

    Public Class ReportGenerator

    End Class

    Public Class Licensing
        Public Shared Sub GetLicenseBase()
            ' Get the Windows Management Instrumentation object.
            Dim wmi As Object = GetObject("WinMgmts:")

            ' Get the "base boards" (mother boards).
            Dim serial_numbers As String = ""
            Dim mother_boards As Object = wmi.InstancesOf("Win32_BaseBoard")
            For Each board As Object In mother_boards
                serial_numbers &= ", " & board.SerialNumber
            Next board
            If serial_numbers.Length > 0 Then serial_numbers = _
                serial_numbers.Substring(2)

            Dim objMOS As ManagementObjectSearcher
            Dim objMOC As Management.ManagementObjectCollection
            Dim objMO As Management.ManagementObject
            Dim OSSerial As String = ""

            objMOS = New ManagementObjectSearcher("Select * From Win32_OperatingSystem")
            objMOC = objMOS.Get

            For Each objMO In objMOC
                OSSerial = objMO("SerialNumber")
            Next

            Declares.HashKeyCode = serial_numbers
            Declares.SaltKeyCode = OSSerial
        End Sub

        Public Shared Sub Load30DayDemoLicense()
            'CSI-PH : Customer Serial Integrator - Philippines
            Dim LicenseType As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CSI-PH", "Hash5", Nothing), _
                LicenseExpired As Boolean = Convert.ToBoolean(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CSI-PH", "Hash6", Nothing))
            Dim CSIPH As New Cryptography()

            If IsNothing(LicenseType) = True Then
                My.Computer.Registry.CurrentUser.CreateSubKey("CSI-PH")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash1", CSIPH.EncryptData(Declares.HashKeyCode))     ' Motherboard Serial
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash2", CSIPH.EncryptData(Declares.SaltKeyCode))     ' Operating System Serial
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash3", CSIPH.EncryptData(Now().ToString()))         ' Trial Start Date
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash4", CSIPH.EncryptData(Now().AddDays(30)))        ' Trial End Date
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash5", CSIPH.EncryptData("30-Day Demo"))            ' License Type
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash6", CSIPH.EncryptData(0))                        ' License Expired : 0-False, 1-True
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash7", CSIPH.EncryptData(100))                      ' Max Employee Count
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash8", CSIPH.EncryptData(Now.ToString()))           ' Date Last Used
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash9", CSIPH.EncryptData("Custom Parameter 1"))     ' Company Name
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\CSI-PH", "Hash10", CSIPH.EncryptData("Custom Parameter 2"))    ' Custom Parameter 2

            ElseIf CSIPH.DecryptData(LicenseType) = "30-Day Demo" Then
                Dim LicDateStart As Date = Convert.ToDateTime(CSIPH.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CSI-PH", "Hash3", Nothing))), _
                    LicDateEnd As Date = Convert.ToDateTime(CSIPH.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CSI-PH", "Hash4", Nothing))), _
                    DateLastUsed As Date = Convert.ToDateTime(CSIPH.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CSI-PH", "Hash8", Nothing)))

                If LicenseExpired = True Or Now > LicDateEnd Then
                    MsgBox("Your trial version has expired. Please contact software provider to buy/acquire license to the software.", MsgBoxStyle.Information, "Software Expired")
                    End
                End If

                If Format(Now, "yyyyMMdd") < Format(DateLastUsed, "yyyyMMdd") Then
                    MsgBox("Anti-dating the system date is useless ")
                End If

                If DateDiff(DateInterval.Day, Now, LicDateEnd) <= 10 And DateDiff(DateInterval.Day, Now, LicDateEnd) > 0 Then
                    MsgBox("Your system trial will expire in " + DateDiff(DateInterval.Day, Now, LicDateEnd).ToString + " day(s)", MsgBoxStyle.Information, "Activate License")
                End If
            Else
                ' Check if software is licensed

                Dim MotherboardSerial As String = CSIPH.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CSI-PH", "Hash1", Nothing))
                Dim OperatingSystemSerial As String = CSIPH.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\CSI-PH", "Hash2", Nothing))

                If Not Declares.HashKeyCode = MotherboardSerial Or Not Declares.SaltKeyCode = OperatingSystemSerial Then
                    MsgBox("License Serial/Key is invalid for this machine. Please enter a valid licens and/or contact your software vendor.", MsgBoxStyle.Critical, "Serial Error")
                End If

            End If

        End Sub

        Public Shared Sub ReadAllSettings()
            Try
                Dim appSettings = ConfigurationManager.AppSettings

                If appSettings.Count = 0 Then
                    Console.WriteLine("AppSettings is empty.")
                Else
                    For Each key As String In appSettings.AllKeys
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings(key))
                    Next
                End If
            Catch e As ConfigurationErrorsException
                Console.WriteLine("Error reading app settings")
            End Try
        End Sub

        Public Shared Sub ReadSetting(key As String)
            Try
                Dim appSettings = ConfigurationManager.AppSettings
                Dim result As String = appSettings(key)
                If IsNothing(result) Then
                    result = "Not found"
                End If
                Console.WriteLine(result)
            Catch e As ConfigurationErrorsException
                Console.WriteLine("Error reading app settings")
            End Try
        End Sub

        Public Shared Sub AddUpdateAppSettings(key As String, value As String)
            Try
                Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                Dim settings = configFile.AppSettings.Settings
                If IsNothing(settings(key)) Then
                    settings.Add(key, value)
                Else
                    settings(key).Value = value
                End If
                configFile.Save(ConfigurationSaveMode.Modified)
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name)
            Catch e As ConfigurationErrorsException
                Console.WriteLine("Error writing app settings")
            End Try
        End Sub

    End Class
End Namespace

