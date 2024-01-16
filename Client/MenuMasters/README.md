# Frontend

This application is built with React and Vite, providing a minimal setup for a fast and efficient development environment. Below are the instructions on how to use and run the application.

## Table of Contents

- [Using the application](#using-the-application)
  - [Scripts](#scripts)
  - [Dependencies](#dependencies)
  - [Build](#build)
  - [Testing](#testing)

## Using the application

### Scripts

The following scripts are available for development, testing, and deployment:

- predeploy: Runs before deploying to build the application.
- deploy: Deploys the application to GitHub Pages using gh-pages.
- dev: Starts the development server with Vite.
- build: Compiles TypeScript and builds the application.
- scan:translations: Scans translations using i18next-scanner.
- lint: Lints the code using ESLint.
- preview: Previews the production build locally.
- test: Runs Cypress tests in headless mode.
- test:open: Opens Cypress test runner for interactive testing.

### Dependencies

Start with installing the dependancies with:
   ```
   npm install
   ```


Key dependencies used in this project:

- React: A JavaScript library for building user interfaces.
- Vite: A fast and efficient development server and bundler.
- Chakra UI Icons: Provides a set of accessible icons.
- Axios: A promise-based HTTP client for making requests.
- i18next: An internationalization framework for JavaScript.
- Recoil: A state management library for React.
- Socket.IO-Client: Enables real-time, bidirectional, and event-based communication.

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
