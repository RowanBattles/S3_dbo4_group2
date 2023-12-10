import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    // Get rid of the CORS error
    proxy: {
      "/api": {
        target: "https://localhost:7266",
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
