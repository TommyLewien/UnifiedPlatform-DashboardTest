import * as React from "react";
import ReactDOM from "react-dom";
import CssBaseline from "@mui/material/CssBaseline";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import Button from "@mui/material/Button";
import App from "./app/App";

// ReactDOM.render(<App />, document.querySelector("#root"));
import { createRoot } from "react-dom/client";

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.querySelector("#root")
);

// const container = document.getElementById("app");
// const root = createRoot(container!); // createRoot(container!) if you use TypeScript
// root.render(
//   <App
//   // tab="home"
//   />
// );
