# ServerGit - Unity Project with Parallel Version Control

This repository is configured to work alongside Unity Version Control (formerly Plastic SCM), allowing both Git and Unity Version Control to monitor and manage the same local Unity project folder simultaneously.

## Overview

This setup enables:
- **Unity Version Control**: Continues to work as normal for team collaboration within Unity
- **Git/GitHub**: Provides a backup and additional version control on GitHub

Both systems will track the same files, but operate independently without interfering with each other.

## Setup Instructions

### Step 1: Clone this Repository to Your Unity Project Folder

If you already have a Unity project with Unity Version Control set up:

```bash
# Navigate to your Unity project folder
cd /path/to/your/unity/project

# Initialize Git in the existing folder (if not already initialized)
git init

# Add this repository as remote
git remote add origin https://github.com/alexisdeudon01/ServerGit.git

# Fetch the .gitignore and other files
git fetch origin
git checkout origin/main -- .gitignore

# Or if starting fresh, clone directly:
# git clone https://github.com/alexisdeudon01/ServerGit.git /path/to/your/unity/project
```

### Step 2: Verify .gitignore Configuration

The `.gitignore` file is pre-configured to:
- Ignore Unity Version Control (Plastic SCM) files (`.plastic/`, `plastic.*`, etc.)
- Ignore standard Unity generated files (Library, Temp, Logs, etc.)
- Ignore build artifacts and IDE-specific files

This ensures Git and Unity Version Control don't interfere with each other.

### Step 3: Set Up Automatic Monitoring and Pushing

#### Option A: Using a Watch Script (Recommended for Local Development)

Create and run the `auto-commit.sh` script included in this repository:

```bash
# Make the script executable
chmod +x auto-commit.sh

# Run the script (it will monitor for changes and auto-commit/push)
./auto-commit.sh
```

#### Option B: Using Git Hooks

Set up a post-commit hook to automatically push:

```bash
# Create the hook
cat > .git/hooks/post-commit << 'EOF'
#!/bin/bash
git push origin $(git branch --show-current)
EOF

# Make it executable
chmod +x .git/hooks/post-commit
```

#### Option C: Manual Workflow

Manually commit and push when needed:

```bash
git add .
git commit -m "Your commit message"
git push origin main
```

## How It Works

```
┌─────────────────────────────────────────────────────────┐
│                 Your Unity Project Folder                │
│                                                          │
│  ┌──────────────────┐      ┌──────────────────────────┐ │
│  │ Unity Version    │      │ Git                      │ │
│  │ Control          │      │                          │ │
│  │                  │      │ Monitors same files      │ │
│  │ - Team collab    │      │ - Pushes to GitHub       │ │
│  │ - Cloud backup   │      │ - Additional backup      │ │
│  │ - Unity workflow │      │ - Public/private repo    │ │
│  └──────────────────┘      └──────────────────────────┘ │
│                                                          │
│  .plastic/ (ignored by Git)    .git/ (ignored by UVC)   │
└─────────────────────────────────────────────────────────┘
```

## Important Notes

1. **No Conflicts**: The `.gitignore` ensures Git ignores Unity Version Control files, and Unity Version Control typically ignores `.git/` by default.

2. **Independent Operations**: Changes made through Unity Version Control won't automatically appear in Git and vice versa. You need to commit to both systems separately.

3. **Same Source Files**: Both systems track the same Unity project files (Assets, ProjectSettings, Packages, etc.).

4. **Recommended Workflow**:
   - Use Unity Version Control for day-to-day Unity development
   - Use Git for:
     - Additional backup to GitHub
     - Integration with GitHub features (Actions, Issues, etc.)
     - Sharing code publicly (if desired)

## File Structure

```
YourUnityProject/
├── .git/                  # Git repository (ignored by Unity Version Control)
├── .gitignore             # Git ignore rules
├── .plastic/              # Unity Version Control data (ignored by Git)
├── Assets/                # Tracked by both systems
├── Packages/              # Tracked by both systems
├── ProjectSettings/       # Tracked by both systems
├── auto-commit.sh         # Optional auto-commit script
└── README.md              # This file
```

## Troubleshooting

### Git shows Unity Version Control files
Make sure the `.gitignore` includes:
```
.plastic/
*.plastic.wk
plastic.selector
plastic.wktree
```

### Unity Version Control shows .git files
Add `.git/` to your Unity Version Control ignore configuration (usually in `ignore.conf`).

### Merge conflicts
Since both systems operate independently, there shouldn't be merge conflicts between them. However, if you pull changes from Git that conflict with local changes made via Unity Version Control, resolve them manually.

## License

This project is available for use under standard open-source terms.