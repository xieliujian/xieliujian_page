# xieliujian_page

个人作品集网站，托管于 GitHub Pages，展示 Unity 项目与工具插件。

**线上地址：** https://xieliujian.github.io/xieliujian_page/

---

## 项目结构

```
xieliujian_page/
├── index.html                      # 主页：导航栏 + Hero + 项目卡片 + 工具插件入口
├── style.css                       # 全局样式（深色主题，CSS 变量）
├── assets/thumbnails/              # 项目封面图
├── plugins/
│   └── index.html                  # 工具插件页（GitHub API 动态加载）
├── projects/
│   ├── avatar2/
│   │   ├── index.html              # Avatar 换装系统 V2（内嵌 Unity WebGL）
│   │   └── Build/                  # WebGL 构建产物
│   ├── splatoon/
│   │   └── index.html              # 喷射战士 Demo 展示页
│   └── demo-game/
│       └── index.html              # 项目展示页模板
└── docs/superpowers/plans/         # 开发计划文档
```

---

## 修改记录

| 日期 | 内容 |
|------|------|
| 2026-04-16 | 初始化个人作品集项目结构：`index.html` 主页、`style.css` 全局样式（深色主题）、`projects/demo-game/` 示例项目模板 |
| 2026-04-16 | 新增 `projects/avatar2/`：Avatar 换装系统 V2 项目展示页，包含演示 GIF、功能说明、技术栈介绍 |
| 2026-04-16 | 新增 `projects/splatoon/`：喷射战士 Demo 项目展示页 |
| 2026-04-16 | 新增 `plugins/index.html`：工具插件页，通过 GitHub API 动态拉取 `unity_plugin` 仓库文件列表，支持一键下载 |
| 2026-04-16 | 主页新增"工具插件"分区，添加插件库入口卡片 |
| 2026-04-16 | 完善 `CLAUDE.md` 项目文档，记录技术栈、开发规范及修改记录 |
| 2026-04-16 | 插件页新增 `MightyAndPowerfulGames.rar` 中文描述，支持 `.rar` 图标 |
| 2026-04-17 | `projects/avatar2/` 嵌入 Unity WebGL 播放器，上传 Build 构建产物（~15 MB） |
| 2026-04-18 | 更新 Avatar2 WebGL 构建至最新版本（`webgl.data` 从 4.3 MB 增至 8.5 MB） |
| 2026-04-18 | 修复手机端全屏按钮：改用浏览器原生 Fullscreen API，全屏后自动锁定横屏 |
| 2026-04-18 | 修复 iOS 全屏：改用 CSS 模拟全屏（iOS 不支持 Fullscreen API），检测系统方向锁并提示 |
| 2026-04-18 | Android 退出全屏自动恢复竖屏：先 `lock('portrait')` 再 `unlock()`，替代仅调用 `unlock()` |
| 2026-04-18 | iOS 退出全屏时若仍为横屏，显示"请将设备旋转回竖屏"提示 |
