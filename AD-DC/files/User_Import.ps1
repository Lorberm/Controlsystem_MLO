#     Import-Module ActiveDirectory

#     Author: MLO
#     Date: 19.09.2017
#     Purpose: Importing user from csv(output P4Y) into AD including HomeDrive
#     
#     last change: MLO 20171011


#variables
$Users = Import-Csv -Delimiter ";" -Path "C:\Import\Users.csv"   

foreach ($User in $Users)  
{  
    #variables localscope foreach
    $OU = $User.OU
    $kOU = $User.kOU  
    $pw = "Start123" | ConvertTo-SecureString -AsPlainText -Force 
    $Name = $User.Name 
    $fN = $User.Vorname             
    $AN = $User.Vorname + "." + $User.Name
    $PN = $AN + "@" + "schule.local"             #MLO domain (schule.local) hardcoded into script 20171005
    $Path = "OU=" + $kOU + ", OU= " + $OU +", DC=Schule, DC=local"  # MLO: Need to adept to each domain-structure
    $Detailedname = $User.Vorname + " " + $User.Name
    $mail = $User.Vorname + "." + $User.Name + "@schule.local"
    $Group = $User.kOU
    $SAM = $AN


    try {

        #Exec
        New-ADUser -Name $AN  -DisplayName $Detailedname -UserPrincipalName $PN -GivenName $fN -Surname $Name -AccountPassword $pw -Enabled $true -Path $Path -ChangePasswordAtLogon:$True -EmailAddress $mail
        
        Add-ADGroupMember -Identity $Group -Members $AN

        Add-ADGroupMember -Identity "Schueler" -Members $AN

        Set-ADUser $AN -ProfilePath $null -ScriptPath $null -HomeDrive "P" -HomeDirectory "\\SRVDC250\vol2\home\$SAM"


        # create Folder
        $folder = new-item -Path "\\SRVDC250\vol2\home\$SAM" -ItemType Dir -Force 


        # get ACL of folder
        $acl = get-acl $folder.FullName 


        # new ACL-rule for and add to folder
        $objACE = New-Object System.Security.AccessControl.FileSystemAccessRule($PN,"FullControl","ContainerInherit,ObjectInherit","None","Allow") 
        $acl.AddAccessRule($objACE) 



        # set Owner of folder 
        $acl.SetOwner([System.Security.Principal.NTAccount]"$($PN)") 



        # save new ACL for folder 
        Set-Acl $folder.FullName -AclObject $acl 
       
        -ErrorAction Stop
    }
    catch [System.Exception]
    {
    
    # catch block empty so far due no MTA in current structure.  MLO 20171002
       #variables localscope catch
       # $to = "lorber_m@outlook.com"
       # $From = "user@domain.tld"
       # $MTA = "smtp.innlan.at"
       # $subj = "Failed to Import User from CSV"
       # $bodyText = "Script failed to import user " + $user.Name + " from $file."`
  	#	+ "`nError: " + $_.Exception.Message
     #  $bodyHtml = "Test"
      # $Context.SendMail($to, $subj, $bodyText, $bodyHtml)
       #Exec
      # Send-MailMessage -To "$to" -From "$From" -smtpServer "$MTA"  -Subject "$subj" -Body "$bodyText"
      # $Context.LogMessage($bodyText, "Error")
	 }
}
 erase C:\Import\Users.csv -Force