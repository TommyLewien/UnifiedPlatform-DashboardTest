import { createTheme } from "@mui/material/styles";
import { red } from "@mui/material/colors";
import { blue } from "@mui/material/colors";

// A custom theme for this app
export const themeLight = createTheme({
  palette: {
    background: {
      default: "#e4f0e2",
      paper: "#C3C7C7",
    },
    primary: {
      main: "#4463C4",
    },
    secondary: {
      // used in AppBar
      main: "#4463C4",
      contrastText: "white",
    },
    error: {
      main: red.A400,
    },
    text: {
      primary: "#0",
      secondary: "#094F48",
    },
  },
});

export const themeDark = createTheme({
  palette: {
    background: {
      default: "#393D55",
      paper: "#788383",
    },

    primary: {
      main: "#A6B2EB",
    },
    secondary: {
      // used in AppBar
      main: "#0d2268",
      contrastText: blue[50],
    },
    error: {
      main: red.A400,
    },
    text: {
      primary: "#ffffff",
      secondary: "#B2EFEB",
    },
  },
});
