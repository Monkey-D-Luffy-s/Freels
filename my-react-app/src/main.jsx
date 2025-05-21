import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.jsx";
import Navbar from "./components/Navbar.jsx";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import UploadVideo from "./components/UploadVideo.jsx";
import Reels, { loadReels } from "./components/Reels.jsx";

var routes = createBrowserRouter([
  {
    path: "/",
    element: <Navbar />,
    children: [
      { index: true, element: <App /> },
      { path: "upload", element: <UploadVideo /> },
      { path: "Reels", element: <Reels />, loader: loadReels },
    ],
  },
]);

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <RouterProvider router={routes} />
  </StrictMode>
);
