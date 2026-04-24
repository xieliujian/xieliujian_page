# 从 com.spacetime.gpuskin.sample@main 拉取 webgl/Build 四件套。
# 在终端执行：  cd 本目录;  .\fetch-build.ps1
# curl 会输出进度表（% / 已下载 / 速度 / ETA），大文件需数分钟请耐心等待。

$ErrorActionPreference = "Stop"
$Base = "https://raw.githubusercontent.com/xieliujian/com.spacetime.gpuskin.sample/main/webgl/Build"
$OutDir = Join-Path $PSScriptRoot "webgl\Build"
$Files = @("webgl.loader.js", "webgl.framework.js", "webgl.data", "webgl.wasm")

if (-not (Test-Path $OutDir)) {
  New-Item -ItemType Directory -Path $OutDir -Force | Out-Null
}

$total = $Files.Count
for ($i = 0; $i -lt $total; $i++) {
  $f = $Files[$i]
  $n = $i + 1
  $dest = Join-Path $OutDir $f
  Write-Host ""
  Write-Host "[$n/$total] $f -> $dest" -ForegroundColor Cyan
  & curl.exe -fSL --connect-timeout 60 -o $dest "$Base/$f"
  if ($LASTEXITCODE -ne 0) {
    throw "curl failed for $f (exit $LASTEXITCODE)"
  }
  Write-Host "OK" $((Get-Item $dest).Length) "bytes" -ForegroundColor Green
}

Write-Host ""
Write-Host "Done. Build files:" -ForegroundColor Cyan
Get-ChildItem $OutDir | Format-Table Name, Length
