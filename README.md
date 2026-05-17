![logo](https://devdeer.blob.core.windows.net/shared/codingfreaks/obs_logo.png)

# obscene

A little helper for content creators sharing their screen with OBS.

## Idea

As a creator I don't see the same as my viewers when sharing my screen. Here is an example of this.

What my viewer see:
<img src="https://devdeer.blob.core.windows.net/shared/codingfreaks/obscene/yt_cam.png" style="width:20%" />

What I see on my screen:
<img src="https://devdeer.blob.core.windows.net/shared/codingfreaks/obscene/desktop.png" style="width:20%" />

When obscene is ready-to-use it will show my desktop to me like this:
<img src="https://devdeer.blob.core.windows.net/shared/codingfreaks/obscene/mask_cam.png" style="width:20%" />

However if viewers see this:
<img src="https://devdeer.blob.core.windows.net/shared/codingfreaks/obscene/yt_right.png" style="width:20%" />

I would see:
<img src="https://devdeer.blob.core.windows.net/shared/codingfreaks/obscene/mask_right.png" style="width:20%" />

## Requirements

- .NET 10 SDK (`dotnet --list-sdks`)
- Obsence only runs on Windows!

## Testing

Open a terminal.

1. Clone the code locally.
2. From the root directory execute `dotnet run --project .\src\Ui\Ui.TestConsole\`.

You should see a red circle. Hit any key in the terminal to exit the program.
