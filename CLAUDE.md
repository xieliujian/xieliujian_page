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
├── index.html                      # 主页：导航栏 + Hero + 项目卡片网格 + 页脚
├── style.css                       # 全局样式（所有页面共用）
├── assets/
│   └── thumbnails/                 # 项目封面图（PNG/JPG，命名与项目目录一致）
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

## 注意事项

- Unity WebGL 文件体积较大（通常数十 MB），**不要**将 `Build/` 目录下的构建产物提交到 Git（可在 `.gitignore` 中排除，用 Git LFS 或直接上传）
- GitHub Pages 不支持服务端逻辑，所有功能必须在前端实现
- 封面图若使用外链（如 GitHub raw），需确保图片可公开访问
