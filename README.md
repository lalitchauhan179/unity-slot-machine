# 🎰 Unity Slot Machine Game

## 📄 Overview
This project is a **classic slot machine game** built in **Unity**.  
It demonstrates:
- 🎮 Slot mechanics with reels, balance, and betting
- 🎲 Random Number Generator (RNG) for fair outcomes
- 💰 Payouts & win checking
- 🕹️ Interactive **handle animation**
- 🖥️ WebGL build for browser play

The project follows **clean code principles**, is fully modular, and structured for readability.

---

## 🌐 Play Online
👉 **[Play the Slot Game on Netlify](https://inspiring-lebkuchen-304934.netlify.app/)**  

⚠️⚠️ **IMPORTANT: Always run the build in *FULL SCREEN MODE* for the best experience** ⚠️⚠️  
*(The UI and reel alignment are designed for fullscreen play, both on Netlify and in WebGL builds.)*

---

## 🎮 How to Play
1. Start with a default balance of **$1000**.
2. Use **Increase Bet / Decrease Bet** buttons to adjust your bet (`$10 – $100`).
3. Press **Spin** to:
   - Pull the slot handle
   - Spin all reels with smooth animations
   - Check for **wins on the middle line only** (all symbols must match).
4. If you win:
   - The payout is calculated based on bet × number of matching symbols
   - Winning symbols flash with a highlight animation
5. If you lose:
   - Balance decreases by the bet amount
6. Keep playing until your balance runs out! 💸

---

## 🛠️ Project Setup

### Prerequisites
- Unity **2022.3 LTS** (or compatible)
- Git
- Web browser (for WebGL build)

### Clone & Open Project
```bash
git clone https://github.com/lalitchauhan179/unity-slot-machine/.git
cd unity-slot-machine
