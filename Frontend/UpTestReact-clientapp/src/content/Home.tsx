import * as React from "react";
import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import Link from "@mui/material/Link";
import CssBaseline from "@mui/material/CssBaseline";
import { ThemeProvider, createTheme } from "@mui/material/styles";

import ProTip from "./ProTip";

function Copyright() {
  return (
    <Typography variant="body2" color="text.secondary" align="center">
      {"Copyright © "}
      <Link color="inherit" href="https://material-ui.com/">
        Your Website
      </Link>{" "}
      {new Date().getFullYear()}.
    </Typography>
  );
}

export default function Home() {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: { xs: "column", md: "row" },
        alignItems: "center",
        bgcolor: "orange",
        overflow: "hidden",
        borderRadius: "12px",
        boxShadow: 1,
        fontWeight: "bold",
        marginRight: "1px",
        marginLeft: "1px",
      }}
    >
      <Typography paragraph>The Best Ever UP Dashboard</Typography>
      <Typography paragraph>Written as a first UP experiment by Tommy</Typography>
      <Typography variant="h4" component="h1" gutterBottom>
        Discom UpReact
      </Typography>
      <ProTip />
      <Copyright />
    </Box>
  );
}
