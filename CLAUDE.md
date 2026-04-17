# CLAUDE.md

## 项目概述

个人作品集网站，托管于 GitHub Pages，用于展示 Unity WebGL 项目。主页列出项目卡片，每个项目有独立子页面内嵌 Unity WebGL 构建产物。

**线上地址：** https://xieliujian.github.io/xieliujian_page/

## 技术栈

- **语言：** HTML5、CSS3、Vanilla JS（无框架、无构建工具）
- **样式：** CSS 变量 + Grid/Flexbox，统一深色主题
- **部署：** GitHub Pages（`main` 分支根目录）
- **Unity 构建要求：** WebGL，Compression Format 设为 **Disabled**

## 文件结构

```
xieliujian_page/
├── index.html                      # 主页：导航栏 + Hero + 项目卡片网格 + 工具插件入口 + 页脚
├── style.css                       # 全局样式（所有页面共用）
├── assets/
│   └── thumbnails/                 # 项目封面图（PNG/JPG，命名与项目目录一致）
├── plugins/
│   └── index.html                  # 工具插件页：动态读取 GitHub API 展示插件列表
├── projects/
│   ├── avatar2/
│   │   └── index.html              # Avatar 换装系统 V2 项目页
│   └── demo-game/
│       ├── index.html              # 项目展示页（iframe 方式加载 Unity）
│       └── Build/                  # Unity WebGL 构建产物目录
└── docs/
    └── superpowers/plans/          # 开发计划文档（内部参考）
```

## 开发规范

### 样式

- 所有颜色、圆角、过渡时长均通过 `style.css` 中的 CSS 变量定义，**不在 HTML 中写内联样式**
- 主页引用：`href="style.css"`；子项目页引用：`href="../../style.css"`
- 新增 UI 组件优先复用已有 class（`.project-card`、`.unity-container`、`.navbar` 等）

### 添加新项目（标准流程）

1. 在 `projects/` 下新建目录，如 `projects/my-game/`
2. 复制 `projects/demo-game/index.html`，修改标题、描述
3. Unity 构建（关闭 Compression）后将产物放入 `projects/my-game/Build/`
4. 将 Unity 生成的 `index.html` 改名为 `unity.html` 放入同目录
5. 将封面截图放到 `assets/thumbnails/my-game.png`（建议 16:9）
6. 在主页 `index.html` 的 `.projects-grid` 中复制一个 `.project-card` 块，填写名称、描述、封面路径和链接

### Git 提交规范

使用约定式提交（Conventional Commits）：

```
feat: 添加新项目页面
fix: 修复封面图路径
chore: 更新目录结构
style: 调整卡片悬浮样式
docs: 更新 README
```

## 工具插件页（plugins/）

- 页面通过 **GitHub API** (`https://api.github.com/repos/xieliujian/unity_plugin/contents`) 动态拉取文件列表，无需手动维护
- 文件直接使用 `download_url`（`raw.githubusercontent.com`）触发浏览器下载；目录跳转至 GitHub 页面
- `README.md` 在渲染时自动过滤，不展示在列表中
- 若需新增插件，直接向 [xieliujian/unity_plugin](https://github.com/xieliujian/unity_plugin) 仓库推送文件即可，页面自动同步

## 修改记录

| 日期 | 内容 |
|------|------|
| 2026-04-16 | 初始化个人作品集项目结构：`index.html` 主页、`style.css` 全局样式（深色主题）、`projects/demo-game/` 示例项目模板 |
| 2026-04-16 | 新增 `projects/avatar2/`：Avatar 换装系统 V2 项目展示页，包含演示 GIF、功能说明、技术栈介绍 |
| 2026-04-16 | 新增 `projects/splatoon/`：喷射战士 Demo 项目展示页 |
| 2026-04-16 | 新增 `plugins/index.html`：工具插件页，通过 GitHub API 动态拉取 `unity_plugin` 仓库文件列表，支持一键下载 |
| 2026-04-16 | 主页新增"工具插件"分区，添加插件库入口卡片 |
| 2026-04-16 | 完善 `CLAUDE.md` 项目文档，记录技术栈、开发规范及修改记录 |

---

## 注意事项

- Unity WebGL 文件体积较大（通常数十 MB），**不要**将 `Build/` 目录下的构建产物提交到 Git（可在 `.gitignore` 中排除，用 Git LFS 或直接上传）
- GitHub Pages 不支持服务端逻辑，所有功能必须在前端实现
- 封面图若使用外链（如 GitHub raw），需确保图片可公开访问
