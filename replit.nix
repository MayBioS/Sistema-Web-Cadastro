{ pkgs }: {
	deps = [
		pkgs.mono4
  pkgs.dotnet-sdk
    pkgs.omnisharp-roslyn
	];
}