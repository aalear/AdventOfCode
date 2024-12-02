$input = Read-Host 'Input'
$floor = 0
$index = 0
foreach ($char in [char[]]$input) {
    $index++
    if($char -eq '(') {
        $floor++
    } else {
        $floor--
    }
    if($floor -eq -1) {
        Write-Host $index
        break
    }
}