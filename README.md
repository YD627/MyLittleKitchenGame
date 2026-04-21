# 我的小厨房 (My Little Kitchen)

一个温馨可爱的3D厨房模拟/烹饪游戏，使用Unity引擎开发。扮演厨师，在快节奏的订单中完成切菜、烹饪、装盘与上菜，体验经营小厨房的忙碌与乐趣！

## 🎮 游戏简介

欢迎来到“我的小厨房”！这是一款沉浸式厨房模拟游戏。您将置身于一个设备齐全的厨房中，从准备食材开始，完成切割、煎炸、组装到上菜的全套流程。小心不要烧焦食物，并高效地为顾客提供美味佳肴！

## ✨ 核心玩法与功能

### 🍳 核心烹饪循环
*   **移动与交互**：使用**方向键**操控厨师在厨房中自由移动。
*   **食材处理**：
    *   按 **E键** 从柜台取出食材。
    *   按 **F键** 对食材（如蔬菜）进行**切割**。
*   **烹饪与组装**：
    *   将肉饼放在煎锅上烹饪，需注意火候。
    *   将处理好的食材组合成完整的菜肴。
*   **服务与清理**：
    *   将做好的菜肴上交给顾客。
    *   可以丢弃失败或不需要的食物。

### ⚙️ 系统功能
*   **完整的用户界面**：
    *   **开始菜单**：美观的入口，引导玩家进入游戏。
    *   **游戏设置**：
        *   **音频控制**：可单独调节**游戏音乐**和**音效**的音量大小。
        *   **按键设置**：支持完全自定义操作按键，提供个性化的操控体验。
*   **现代输入管理**：基于Unity全新的Input System构建，确保输入响应精准可靠。

## 🚀 如何开始

### 前置要求
*   [Unity Hub](https://unity.com/download) 和 **Unity 编辑器**（建议使用 2021.3 LTS 或更高版本）。
*   Git（用于克隆仓库）。

### 安装与运行步骤
1.  **克隆仓库**
*   bash
*   git clone https://github.com/YD627/MyLittleKitchenGame.git
2.  **用Unity打开项目**
*   打开Unity Hub，点击`添加`按钮，选择克隆下来的项目根文件夹（即包含`Assets`、`ProjectSettings`的目录）。
*   在项目列表中点击该项目，Unity编辑器将启动并加载。
3.  **进入游戏**
*   在Unity编辑器的`Project`窗口，导航到 `Assets/Scenes` 文件夹。
*   找到并打开主菜单场景 **`0-GameMenu.unity`**。
4.  **点击运行**
*   在Unity编辑器顶部点击播放(▶️)按钮，即可开始游戏。

## 🎯 游戏操作（默认键位）

| 动作 | 按键 |
| :--- | :--- |
| 移动角色 | **上、下、左、右 方向键** |
| 拾取/放置物品 | **E** |
| 切割食材 | **F** |
| 打开/关闭设置 | (请在游戏内查看) |
| *其他操作* | *(游戏内可自定义)* |

> **提示**：所有操作按键均可在游戏内的“设置”菜单中按喜好修改。

## 🖼️ 游戏截图
*(此处可添加游戏开始界面、厨房场景、烹饪过程、设置菜单的截图)*

## 📁 项目结构
```
MyLittleKitchenGame/

├── Assets/           # 游戏资源文件夹（模型、脚本、材质、场景等）

├── Logs/             # 日志文件

├── Packages/         # Unity包管理文件夹

├── ProjectSettings/  # Unity项目设置

├── UserSettings/     # 用户编辑器设置

├── .vs/              # Visual Studio 相关配置

├── .gitignore        # Git忽略文件配置

└── 我的小厨房.sln     # Visual Studio解决方案文件
```

## 🔨 技术栈

*   **游戏引擎**：Unity 2021.3 LTS 或更高版本
*   **编程语言**：C#
*   **输入系统**：Unity New Input System
*   **音频管理**：Unity Audio Mixer
*   **版本控制**：Git & GitHub

## 🤝 贡献指南

欢迎提交Issues和Pull Requests来帮助改进这个项目！
1.  Fork 本仓库。
2.  创建您的功能分支 (`git checkout -b feature/AmazingFeature`)。
3.  提交您的更改 (`git commit -m 'Add some AmazingFeature'`)。
4.  推送到分支 (`git push origin feature/AmazingFeature`)。
5.  开启一个 Pull Request。

## 📧 联系与支持

*   **项目发起与维护**：YD627
*   **GitHub**：[YD627](https://github.com/YD627)
*   如有问题或建议，欢迎在GitHub仓库中提交 [Issue](https://github.com/YD627/MyLittleKitchenGame/issues)。

---

> 游戏持续开发中！更多食谱、顾客系统、评分挑战和全新关卡正在路上，敬请期待！
