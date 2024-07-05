# ![icon](PathEd/app.ico) PathEd

English | [简体中文](README.chs.md)

Without PathEd, it can be quite cumbersome to handle the old-school semicolon-devided PATH variable safely.

- PathEd has no dependencies besides the .NET Framework 4.0 and can be deployed with any installer, for example.
- Editing the PATH within your setup is just one single exec command instead of using proprietary PATH manipulation plugins, etc.

## Usage

`path.exe [/a] [/A] [/d] [/D] [/v] [/V] [/?] the\path\to\add\or\delete`

| Arg  | operate | level  |
| ---- | ------- | ------ |
| `/v` | view    |  user  |
| `/V` | view    | system |
| `/a` | add     |  user  |
| `/A` | add     | system |
| `/d` | remove  |  user  |
| `/D` | remove  | system |
| `/?` | help    |        |
| none | view    |  user  |

## Examples

### Add a value to the Windows PATH

`PathEd.exe /A "C:\example dir\path"`

### Remove a value from the Windows PATH

`PathEd.exe /D "C:\example dir\path"`

### Usage in a NSIS install script

PathEd is used in the [RepoZ](https://github.com/awaescher/RepoZ) NSIS install script to [add](https://github.com/awaescher/RepoZ/blob/496d4f7539670112772b81e208c2ce650164e101/_setup/RepoZ.nsi#L59) and [remove](https://github.com/awaescher/RepoZ/blob/496d4f7539670112772b81e208c2ce650164e101/_setup/RepoZ.nsi#L92) the application location to the Windows PATH.

## Noteworthy

PathEd will:

- Just add values if they are new to the PATH. So it can be called multiple times.
- Ignore removals if the value is not part of the PATH. So it can be called multiple times as well.
- Compare values against the PATH (whether it should add or can remove values) case-insensitive.
- Remove values even if the PATH defines them in quotes.

As always, you'll need to add quotes to the value if it contains spaces (like shown in the examples). Otherwise, Windows will split them up as multiple arguments.

## LICENSE

MIT License.

## Other

For more mini tools for Windows command line, go to: [kagurazakayashi/NyarukoMiniTools](https://github.com/kagurazakayashi/NyarukoMiniTools)
