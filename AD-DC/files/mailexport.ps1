#
#  Author: MLO
#  Purpose: Create CSV on fileshare with user-mail
#  Created: 25.10.2017
#



#variables
$path = 'C:\Temp\mail.csv'


#exec
try {
    Get-ADUser -Properties DisplayName, Emailaddress -Filter {mail -like '*'} |
     foreach {
                New-Object psobject -Property @{
                                                f1=$_.DisplayName
                                                f2=$_.EmailAddress
                                                }
            } | select f1, f2 | Export-Csv -NoTypeInformation -Delimiter ';' $path



Remove-Item \\SRVFS249\Temp\mail.csv
Move-Item -Path $path -Destination '\\SRVFS249\Temp'

}
catch {
    write-hoste 'Fehler beim erstellen der CSV!'
}