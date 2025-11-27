
#!/bin/bash
# Auto-commit and push script for Unity project
# This script monitors for changes and automatically commits and pushes to Git
# while working alongside Unity Version Control
echo "Starting Git Auto-Commit Script..."
# Configuration
WATCH_INTERVAL=60  # Check for changes every 60 seconds
BRANCH="main"      # Branch to push to

# Flag to control the main loop
RUNNING=true

# Cleanup function for graceful shutdown
cleanup() {
    echo ""
    echo "Shutting down gracefully..."
    RUNNING=false
}

# Set up signal handlers for graceful shutdown
trap cleanup SIGINT SIGTERM

echo "=========================================="
echo "Git Auto-Commit Script for Unity Project"
echo "=========================================="
echo "Monitoring for changes every ${WATCH_INTERVAL} seconds..."
echo "Press Ctrl+C to stop"
echo ""

# Function to check if there are changes to commit
has_changes() {
    git status --porcelain | grep -q .
}

# Function to commit and push changes
commit_and_push() {
    local timestamp=$(date '+%Y-%m-%d %H:%M:%S')
    
    echo "[${timestamp}] Changes detected, committing..."
    
    # Stage all changes (respects .gitignore)
    git add -A
    
    # Check if there are staged changes after filtering
    if ! git diff --cached --quiet; then
        # Create commit message with timestamp
        local commit_msg="Auto-commit: ${timestamp}"
        
        if git commit -m "${commit_msg}"; then
            # Push to remote only if commit succeeded
            echo "[${timestamp}] Pushing to origin/${BRANCH}..."
            if git push origin "${BRANCH}"; then
                echo "[${timestamp}] Push successful!"
            else
                echo "[${timestamp}] Push failed. Will retry on next check."
            fi
        else
            echo "[${timestamp}] Commit failed. Will retry on next check."
        fi
    else
        echo "[${timestamp}] No changes to commit after filtering."
    fi
    
    echo ""
}

# Main loop with graceful shutdown support
while $RUNNING; do
    if has_changes; then
        commit_and_push
    fi
    
    # Sleep with interrupt support
    sleep "${WATCH_INTERVAL}" &
    wait $!
done

echo "Script terminated."
