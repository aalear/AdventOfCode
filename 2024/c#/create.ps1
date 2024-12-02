param (
    [parameter(Position = 0, Mandatory = $true)]
    [int]$dayNum
)

$dir = "Day$($dayNum)"

New-Item -ItemType Directory -Path $dir

Set-Location $dir

dotnet new aoc