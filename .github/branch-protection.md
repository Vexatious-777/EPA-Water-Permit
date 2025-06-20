# Branch Protection Rules

This document outlines the recommended branch protection rules for this repository. These settings should be configured in the GitHub repository settings.

## Main Branch Protection

Configure the following settings for the `main` branch:

### Required Status Checks
- Require branches to be up to date before merging
- Required checks:
  - `validate` workflow
  - `build` workflow
  - `security` workflow

### Required Pull Request Reviews
- Required approving reviews: 1
- Dismiss stale pull request approvals when new commits are pushed
- Require review from Code Owners
- Require conversation resolution before merging

### Required Signatures
- Require signed commits
- Require linear history

### Branch Restrictions
- Do not allow force pushes
- Do not allow deletions

## Develop Branch Protection

Configure the following settings for the `develop` branch:

### Required Status Checks
- Require branches to be up to date before merging
- Required checks:
  - `validate` workflow
  - `build` workflow

### Required Pull Request Reviews
- Required approving reviews: 1
- Dismiss stale pull request approvals when new commits are pushed
- Require conversation resolution before merging

### Branch Restrictions
- Do not allow force pushes
- Do not allow deletions

## Feature Branch Naming Convention

Enforce branch naming pattern:
- `feature/*`
- `bugfix/*`
- `hotfix/*`
- `release/*`

## Environment Protection Rules

### Production Environment
- Required reviewers: 2
- Wait timer: 10 minutes
- Allow specified actors only
- Require approval for all deployment attempts 