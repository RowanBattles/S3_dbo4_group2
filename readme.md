# Infosupport_Tortillias

Welcome to Infosupport_Tortillias! This application is built with React and Vite, providing a minimal setup for a fast and efficient development environment. Below are the instructions on how to use and run the application.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Using the application](#using-the-application)
  - [Scripts](#scripts)
  - [Dependencies](#dependencies)
  - [Development](#development)
  - [Build](#build)
  - [Testing](#testing)
  - [Deployment](#deployment)

## Getting Started

### Prerequisites

Make sure you have the following installed on your machine:

- Node.js (v14.0.0 or higher)
- npm (v7.0.0 or higher)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/bassmi12/Infosupport_Tortillias.git
   cd Infosupport_Tortillias
   ```
2. install dependancies
   ```
   npm install
   ```

## Using the application

### Scripts

The following scripts are available for development, testing, and deployment:

1. predeploy: Runs before deploying to build the application.
2. deploy: Deploys the application to GitHub Pages using gh-pages.
3. dev: Starts the development server with Vite.
4. build: Compiles TypeScript and builds the application.
5. scan:translations: Scans translations using i18next-scanner.
6. lint: Lints the code using ESLint.
7. preview: Previews the production build locally.
8. test: Runs Cypress tests in headless mode.
9. test:open: Opens Cypress test runner for interactive testing.

### Dependencies

Key dependencies used in this project:

React: A JavaScript library for building user interfaces.
Vite: A fast and efficient development server and bundler.
Chakra UI Icons: Provides a set of accessible icons.
Axios: A promise-based HTTP client for making requests.
i18next: An internationalization framework for JavaScript.
Recoil: A state management library for React.
Socket.IO-Client: Enables real-time, bidirectional, and event-based communication.
For a complete list, refer to the package.json file.

### Build

To build the application for production, run:

```
npm run build
```

### Testing

To run Cypress tests in headless mode, use:

```
npm test
```

For interactive testing, run:

```
npm run test:open
```

### Deployment

Deploy the application to GitHub Pages using:

```
npm run deploy
```
