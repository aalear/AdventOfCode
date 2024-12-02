$input = Read-Host 'Input'
[char[]]$input | ForEach-Object  { if ($_ -eq '(') { $floor++ } else { $floor-- } }
Write-Host $floor
