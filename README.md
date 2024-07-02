# ![icon](PathEd/app.ico) PathEd

安全地处理老式的分号分隔的 PATH 变量

Without PathEd, it can be quite cumbersome to handle the old-school semicolon-devided PATH variable safely. 

PathEd 除了 .NET Framework 4.0 之外没有任何依赖项，并且可以与任何安装程序一起部署。
在设置中编辑 PATH 只需一个 exec 命令，而无需使用专有的 PATH 操作插件等。

PathEd has no dependencies besides the .NET Framework 4.0 and can be deployed with any installer, for example.
Editing the PATH within your setup is just one single exec command instead of using proprietary PATH manipulation plugins, etc.

## Examples | 示例

### Add a value to the Windows PATH | 向 Windows PATH 添加一个值

`PathEd.exe /A "C:\examples dir\path"`

### Remove a value from the Windows PATH | 从 Windows PATH 中删除一个值

`PathEd.exe /D "C:\examples dir\path"`

### Usage in a NSIS install script | 在 NSIS 安装脚本中的使用

PathEd is used in the [RepoZ](https://github.com/awaescher/RepoZ) NSIS install script to [add](https://github.com/awaescher/RepoZ/blob/496d4f7539670112772b81e208c2ce650164e101/_setup/RepoZ.nsi#L59) and [remove](https://github.com/awaescher/RepoZ/blob/496d4f7539670112772b81e208c2ce650164e101/_setup/RepoZ.nsi#L92) the application location to the Windows PATH.

## 注意事项

PathEd 将 ...

- ... 如果值是 PATH 中的新值，则只添加它们。因此可以多次调用它。
- ... 如果值不是 PATH 的一部分，则忽略删除。因此也可以多次调用它。
- ... 将值与 PATH 进行比较（无论它是否应该添加或可以删除​​值），不区分大小写。
- ... 删除值，即使 PATH 在引号中定义它们。

与往常一样，如果值包含空格，则需要为值添加引号（如示例中所示）。否则，Windows 会将它们拆分为多个参数。

## Noteworthy

PathEd will ...

- ... just add values if they are new to the PATH. So it can be called multiple times.
- ... ignore removals if the value is not part of the PATH. So it can be called multiple times as well.
- ... compare values against the PATH (whether it should add or can remove values) case-insensitive.
- ... remove values even if the PATH defines them in quotes.

As always, you'll need to add quotes to the value if it contains spaces (like shown in the examples). Otherwise, Windows will split them up as multiple arguments.
