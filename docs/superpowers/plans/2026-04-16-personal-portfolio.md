# Personal Portfolio + Unity WebGL Showcase 实现计划

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** 构建一个托管在 GitHub Pages 上的个人作品集网站，主页展示个人介绍和项目卡片，每个 Unity WebGL 项目有独立页面。

**Architecture:** 纯静态 HTML + CSS + JS 多页站点。主页列出所有项目卡片，点击跳转到各项目子目录的独立页面，项目页面直接加载 Unity WebGL 构建产物（通过 `<iframe>` 或直接内嵌 canvas）。所有文件托管在 GitHub Pages，Unity 构建时关闭压缩（Compression Format: Disabled）以避免 MIME 类型问题。

**Tech Stack:** HTML5, CSS3（Grid/Flexbox，CSS 变量），Vanilla JS（无框架），GitHub Pages

---

## 文件结构

```
xieliujian_page/
├── index.html                    # 主页：个人介绍 + 项目卡片网格
├── style.css                     # 全局样式（颜色变量、卡片、布局）
├── assets/
│   └── thumbnails/               # 项目封面图（PNG/JPG）
│       └── placeholder.png       # 占位封面图
└── projects/
    └── demo-game/                # 示例项目目录（可复制作为模板）
        ├── index.html            # 项目页：Unity 全屏展示 + 返回按钮
        └── Build/                # Unity WebGL 构建产物放这里（.gitkeep 占位）
            └── .gitkeep
```

---

## Task 1: 初始化目录结构

**Files:**
- Create: `assets/thumbnails/` 目录
- Create: `projects/demo-game/Build/.gitkeep`

- [ ] **Step 1: 创建目录和占位文件**

```bash
mkdir -p assets/thumbnails
mkdir -p projects/demo-game/Build
echo "" > projects/demo-game/Build/.gitkeep
```

- [ ] **Step 2: 验证目录结构**

```bash
find . -type f -not -path './.git/*' -not -path './docs/*'
```

期望看到 `.gitkeep` 文件存在。

- [ ] **Step 3: Commit**

```bash
git add assets/ projects/
git commit -m "chore: initialize project directory structure"
```

---

## Task 2: 全局样式 style.css

**Files:**
- Create: `style.css`

- [ ] **Step 1: 创建 style.css**

内容如下（完整代码）：

```css
/* CSS 变量 */
:root {
  --bg: #0d1117;
  --surface: #161b22;
  --border: #30363d;
  --accent: #58a6ff;
  --accent-hover: #79c0ff;
  --text: #e6edf3;
  --text-muted: #8b949e;
  --radius: 12px;
  --transition: 0.2s ease;
}

*, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

html { scroll-behavior: smooth; }

body {
  background: var(--bg);
  color: var(--text);
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif;
  line-height: 1.6;
}

a { color: var(--accent); text-decoration: none; }
a:hover { color: var(--accent-hover); }

/* 导航栏 */
.navbar {
  position: sticky;
  top: 0;
  z-index: 100;
  background: rgba(13, 17, 23, 0.85);
  backdrop-filter: blur(8px);
  border-bottom: 1px solid var(--border);
  padding: 0 2rem;
  height: 56px;
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.navbar .logo { font-weight: 700; font-size: 1.1rem; color: var(--text); }
.navbar .back-link { font-size: 0.9rem; }

/* Hero 区域 */
.hero {
  max-width: 760px;
  margin: 0 auto;
  padding: 5rem 2rem 3rem;
  text-align: center;
}
.hero h1 { font-size: 2.5rem; font-weight: 800; margin-bottom: 0.75rem; }
.hero p { font-size: 1.1rem; color: var(--text-muted); max-width: 480px; margin: 0 auto 1.5rem; }
.hero .links { display: flex; gap: 1rem; justify-content: center; flex-wrap: wrap; }
.hero .links a {
  padding: 0.45rem 1.1rem;
  border: 1px solid var(--border);
  border-radius: 6px;
  font-size: 0.9rem;
  transition: border-color var(--transition), color var(--transition);
}
.hero .links a:hover { border-color: var(--accent); }

/* 项目区域 */
.section {
  max-width: 1100px;
  margin: 0 auto;
  padding: 2rem 2rem 5rem;
}
.section h2 {
  font-size: 1.4rem;
  font-weight: 700;
  margin-bottom: 1.5rem;
  padding-bottom: 0.5rem;
  border-bottom: 1px solid var(--border);
}

/* 项目卡片网格 */
.projects-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
  gap: 1.25rem;
}
.project-card {
  background: var(--surface);
  border: 1px solid var(--border);
  border-radius: var(--radius);
  overflow: hidden;
  transition: border-color var(--transition), transform var(--transition);
  display: flex;
  flex-direction: column;
  text-decoration: none;
  color: var(--text);
}
.project-card:hover {
  border-color: var(--accent);
  transform: translateY(-3px);
  color: var(--text);
}
.project-card img {
  width: 100%;
  aspect-ratio: 16/9;
  object-fit: cover;
  background: var(--border);
}
.project-card .card-body { padding: 1rem 1.25rem 1.25rem; flex: 1; display: flex; flex-direction: column; }
.project-card .card-title { font-size: 1rem; font-weight: 700; margin-bottom: 0.4rem; }
.project-card .card-desc { font-size: 0.875rem; color: var(--text-muted); flex: 1; }
.project-card .card-tag {
  display: inline-block;
  margin-top: 0.75rem;
  font-size: 0.75rem;
  padding: 0.2rem 0.6rem;
  border-radius: 4px;
  background: rgba(88, 166, 255, 0.12);
  color: var(--accent);
}

/* 项目展示页 */
.unity-container {
  width: 100%;
  max-width: 960px;
  margin: 2rem auto;
  padding: 0 1rem;
}
.unity-container h1 { font-size: 1.5rem; margin-bottom: 0.5rem; }
.unity-container .desc { color: var(--text-muted); margin-bottom: 1rem; font-size: 0.95rem; }
.unity-wrapper {
  position: relative;
  width: 100%;
  aspect-ratio: 16/9;
  background: #000;
  border-radius: var(--radius);
  overflow: hidden;
  border: 1px solid var(--border);
}
.unity-wrapper iframe {
  width: 100%;
  height: 100%;
  border: none;
}

/* 页脚 */
footer {
  text-align: center;
  padding: 2rem;
  color: var(--text-muted);
  font-size: 0.85rem;
  border-top: 1px solid var(--border);
}
```

- [ ] **Step 2: Commit**

```bash
git add style.css
git commit -m "feat: add global stylesheet with dark theme"
```

---

## Task 3: 主页 index.html

**Files:**
- Create: `index.html`（覆盖原有空文件）

- [ ] **Step 1: 创建 index.html**

```html
<!DOCTYPE html>
<html lang="zh-CN">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>xieliujian — Unity 作品集</title>
  <link rel="stylesheet" href="style.css" />
</head>
<body>

  <nav class="navbar">
    <span class="logo">xieliujian</span>
  </nav>

  <section class="hero">
    <h1>xieliujian</h1>
    <p>Unity 开发者 · 游戏 & 互动体验</p>
    <div class="links">
      <a href="https://github.com/xieliujian" target="_blank">GitHub</a>
      <!-- 可在此添加更多链接 -->
    </div>
  </section>

  <section class="section">
    <h2>作品集</h2>
    <div class="projects-grid">

      <!-- 示例项目卡片 —— 复制此块添加新项目 -->
      <a class="project-card" href="projects/demo-game/">
        <img src="assets/thumbnails/demo-game.png"
             onerror="this.style.background='#30363d';this.removeAttribute('src')"
             alt="Demo Game" />
        <div class="card-body">
          <div class="card-title">Demo Game</div>
          <div class="card-desc">这是一个示例 Unity WebGL 项目，展示基本玩法。</div>
          <span class="card-tag">Unity WebGL</span>
        </div>
      </a>

      <!-- 在此添加更多项目卡片 -->

    </div>
  </section>

  <footer>
    <p>© 2026 xieliujian · Built with HTML & CSS</p>
  </footer>

</body>
</html>
```

- [ ] **Step 2: 在浏览器中打开 index.html 验证页面渲染正常**

- [ ] **Step 3: Commit**

```bash
git add index.html
git commit -m "feat: add homepage with hero and projects grid"
```

---

## Task 4: 项目展示页模板

**Files:**
- Create: `projects/demo-game/index.html`

- [ ] **Step 1: 创建项目页**

Unity WebGL 有两种嵌入方式：

**方式一（推荐，Build 文件在同目录）：** 直接使用 Unity 自动生成的 `index.html`（把 Unity 构建时输出的 index.html 放到此目录，再加上返回按钮）

**方式二（项目页自定义）：** 用 `<iframe>` 加载 Unity 自带页面

本模板使用**方式二**，便于统一样式：

```html
<!DOCTYPE html>
<html lang="zh-CN">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Demo Game — xieliujian</title>
  <link rel="stylesheet" href="../../style.css" />
</head>
<body>

  <nav class="navbar">
    <a class="logo" href="../../">xieliujian</a>
    <a class="back-link" href="../../">← 返回作品集</a>
  </nav>

  <div class="unity-container">
    <h1>Demo Game</h1>
    <p class="desc">这是一个示例 Unity WebGL 项目。将 Unity 构建产物放入 Build/ 目录后即可运行。</p>

    <div class="unity-wrapper">
      <!--
        Unity WebGL 嵌入说明：
        1. 在 Unity 中: File → Build Settings → WebGL → Player Settings
           → Publishing Settings → Compression Format 改为 Disabled
        2. 构建后将以下文件放入 Build/ 目录：
           - Build/*.loader.js
           - Build/*.data
           - Build/*.framework.js
           - Build/*.wasm
        3. 将 Unity 生成的 index.html 内容替换此 iframe，
           或直接把 Unity 的 index.html 改名为 unity.html，
           然后修改下方 src 为 "unity.html"
      -->
      <iframe
        src="unity.html"
        allowfullscreen
        title="Demo Game"
      ></iframe>
    </div>
  </div>

  <footer>
    <p>© 2026 xieliujian</p>
  </footer>

</body>
</html>
```

- [ ] **Step 2: 验证页面链接可以从主页跳转到项目页**

- [ ] **Step 3: Commit**

```bash
git add projects/
git commit -m "feat: add project page template with Unity WebGL embed"
```

---

## Task 5: 配置 GitHub Pages

- [ ] **Step 1: 推送代码到 GitHub**

```bash
git push origin main
```

- [ ] **Step 2: 在 GitHub 仓库设置中启用 Pages**

前往 `Settings → Pages → Source`，选择 `Deploy from a branch`，Branch 选 `main`，目录选 `/ (root)`，保存。

- [ ] **Step 3: 等待部署完成，访问 `https://xieliujian.github.io/xieliujian_page/` 验证**

---

## 添加新 Unity 项目（后续流程）

1. 在 Unity 中构建 WebGL（关闭 Compression）
2. 将构建产物复制到 `projects/your-game-name/Build/`
3. 将 Unity 生成的 `index.html` 改名为 `unity.html`，放到 `projects/your-game-name/`
4. 复制 `projects/demo-game/index.html` 到 `projects/your-game-name/index.html`，修改标题和描述
5. 在主页 `index.html` 中复制一个 `.project-card` 块，填写名称、描述和封面图路径
6. 将封面截图放到 `assets/thumbnails/your-game-name.png`
7. `git add . && git commit -m "feat: add your-game-name"`
