param (
    [parameter(Position = 0, Mandatory = $true)]
    [int]$dayNum
)

$day = "Day$($dayNum)"
$projectDir = "./c#/$day"

New-Item -ItemType File -Path "./inputs/$day.txt"
New-Item -ItemType Directory -Path $projectDir

Set-Location $projectDir

dotnet new aoc