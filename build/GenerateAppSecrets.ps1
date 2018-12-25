[cmdletbinding()]
param
(
	[parameter()][string]$Android,
	[parameter()][string]$iOS
)

try {
	$json = @{
		AppCenter = @{
			iOS = "$iOS"
			Android = "$Android"
		}
	}

	$json | ConvertTo-Json -Compress
	exit 0
} catch {
	Write-Error $_.Exception.Message
	exit 1
}