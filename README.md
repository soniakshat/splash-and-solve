# Splash And Solve 🎈🎯

An interactive, educational 3D mobile game built with **Unity** for **Android** devices. **Splash And Solve** makes learning math engaging and fun for students and kids by combining first-person action mechanics with math-solving challenges.

The player explores a low-poly 3D world, solves dynamically generated math questions, and throws colorful water balloons at floating targets containing potential answers.

---

## 🚀 Key Features

- **Gamified Math Learning**: Practice elementary and intermediate arithmetic under pressure.
- **Dynamic Question Generator**: Questions are procedurally generated in real-time, ensuring unique gameplay sessions.
- **Multiple Game Modes**:
  - ➕ **Addition**: Up to double-digit additions.
  - ➖ **Subtraction**: Positive-result subtraction questions.
  - ✖️ **Multiplication**: Up to $20 \times 20$ times tables.
  - ➗ **Division**: Rounded down to the nearest integer.
  - 📊 **Fractions**: Basic identification and representation.
  - 🎲 **Random Mode**: A mixed test of all mathematical operations.
- **Mobile First-Person Controls**: Responsive split-touch input system custom-built for Android.
  - **Left Screen Touch**: Joystick movement.
  - **Right Screen Touch**: Pitch and yaw camera look around.
  - **Running Toggle**: Accelerate movement speed.
  - **Shoot Button**: Throw physical water balloons with parabolic physics.
- **Score & Ammo Economy**:
  - Score $+4$ points for every correct target splashed.
  - Suffer a $-1$ point penalty for incorrect answers.
  - Maintain focus with limited ammunition (15 balloons per round of 10 questions).
- **Haptic & Visual Feedback**: Balloon popping sounds, water splash decals aligning to hit surfaces, target color changes, and device vibration.

---

## 📁 Repository Structure

```tree
splash-and-solve/
├── Assets/
│   ├── Free Stylized Skybox/     # Beautiful custom skybox environment
│   ├── JC_StylizedNature_Lite/   # Low-poly nature assets (trees, rocks)
│   ├── Playground Low Poly/      # Playground structures and decorations
│   ├── Plugins/
│   │   └── Demigiant/            # DOTween plugin for smooth UI transitions
│   ├── PolygonHorrorCarnival/    # Theme and props assets
│   ├── SimpleNaturePack/         # Stylized environment models
│   ├── TextMesh Pro/             # High-quality text assets and fonts
│   └── Splash And Solve/         # Core Game Assets & Code
│       ├── Materials/            # Balloon and target textures
│       ├── Prefabs/              # Balloon, target, and splash decals
│       ├── Scene/
│       │   └── MainScene.unity   # Core Unity scene containing the entire game loop
│       └── Scripts/              # Game Logic scripts (C#)
│           ├── Managers/         # Singletons managing audio, game flow, score, and UI
│           ├── Player/           # Player movement controller and projectile physics
│           ├── Questions/        # Target behaviors and answer mapping
│           ├── Ui/               # HUD display, input triggers, and settings views
│           └── Utils/            # Constants, custom logging, and math generators
├── Packages/
│   ├── manifest.json             # Unity package dependencies and versions
│   └── packages-lock.json        # Locked dependency tree
└── ProjectSettings/              # Unity project configuration files
```

---

## 🛠️ Prerequisites

To run, modify, or build this project, you will need:

- **Unity Editor**: Version `2020.3.39f1` (LTS) or higher.
- **Android Build Support**: If building for mobile (Android SDK & NDK tools).
- **Git**: For version control.

---

## 💻 Installation & Setup

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/soniakshat/splash-and-solve.git
   cd splash-and-solve
   ```

2. **Open the Project in Unity**:
   - Open **Unity Hub**.
   - Click **Add** -> **Add project from disk**.
   - Select the cloned `splash-and-solve` root directory.
   - Select the Editor Version `2020.3.39f1` (if prompted to upgrade, choose to use or download the correct version for maximum compatibility).

3. **Initialize Assets**:
   - Once Unity finishes importing the assets and resolving the dependencies (like TextMesh Pro and DOTween), open the primary game scene:
     `Assets/Splash And Solve/Scene/MainScene.unity`

---

## 🎮 How to Run

### In the Unity Editor (Development Mode)
1. Open the project and make sure the `MainScene` is loaded.
2. Click the **Play** button at the top center of the editor.
3. **Controls**:
   - Press the **Spacebar** to throw water balloons.
   - Use the **Game view** or enable the **Device Simulator** (`Window > General > Device Simulator`) to simulate touch joystick and HUD inputs.

### Build and Deploy on Android (Production Mode)
1. Go to `File > Build Settings...`
2. Select **Android** from the Platform list and click **Switch Platform**.
3. Under **Scenes in Build**, ensure `Assets/Splash And Solve/Scene/MainScene.unity` is checked.
4. Connect your Android device via USB and enable USB Debugging.
5. Click **Build and Run** to compile the `.apk` and deploy it directly onto your device.

---

## 🧪 Running Tests

This project includes the **Unity Test Framework** configuration in `Packages/manifest.json`.

1. To run test suites, open the **Test Runner** window via:
   `Window > General > Test Runner`
2. You can execute/write tests under the **PlayMode** or **EditMode** tabs.
