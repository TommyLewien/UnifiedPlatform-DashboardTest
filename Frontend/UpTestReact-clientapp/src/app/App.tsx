import * as React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import Link from "@mui/material/Link";
import CssBaseline from "@mui/material/CssBaseline";
import { ThemeProvider, createTheme } from "@mui/material/styles";

import AdapterDateFns from "@mui/lab/AdapterDateFns";
import LocalizationProvider from "@mui/lab/LocalizationProvider";

import Button from "@mui/material/Button";

import { themeLight, themeDark } from "../style/theme";
import MiniDrawer from "./TsSideMenu";
import Home from "../content/Home";
import Settings from "../settings/SettingsContainer";
import SettingsTime from "../settings/SettingsTime";

import deLocale from "date-fns/locale/de";
import enLocale from "date-fns/locale/en-US";

// import indentString from "discom-project";

import { HomeContextProvider } from "discom-project";

import {
  SerializationContextProvider,
  LoggingContextProvider,
  combinedUser,
  IdContext,
  loadIdContext,
} from "discom-project";

import { webAPIUrl, navBaseName } from "./AppSettings";
import { UpVersionInfo } from "../content/UpVersionInfo";

const localeMap: any = {
  en: enLocale,
  de: deLocale,
};

const application = "UpTestReact";
const defUserId = "Tommy";
const defSessionId = "Std";

export default function App() {
  document.title = "UpTestReact";
  const [light, setLight] = React.useState(true);
  const [locale, setLocale] = React.useState("de");
  return (
    <LoggingContextProvider>
      <LocalizationProvider
        dateAdapter={AdapterDateFns}
        locale={localeMap[locale]}
      >
        <HomeContextProvider
          webAPIUrl={webAPIUrl}
          application={application}
          userId={defUserId}
          sessionId={defSessionId}
        >
          <ThemeProvider theme={light ? themeLight : themeDark}>
            <Router basename={navBaseName}>
              <CssBaseline />
              <MiniDrawer />

              <Container maxWidth={false} style={{ marginLeft: "50px" }}>
                {/* The surrounding box brings in a right margin which somehow is necessaay because the Container
        only works with a marginLeft */}
                <Box
                  sx={{
                    marginRight: "30px",
                  }}
                >
                  <Typography
                    component="div"
                    style={{ backgroundColor: "#307ab6", height: "10px" }}
                  />

                  <Button onClick={() => setLight((prev) => !prev)}>
                    Toggle Theme
                  </Button>
                  <Button
                    onClick={() =>
                      setLocale((prev) => (prev === "en" ? "de" : "en"))
                    }
                  >
                    {`<${locale}> Toggle Language`}
                  </Button>
                  {/* <Typography
                component="div"
                style={{ backgroundColor: "#44751c" }}
              >
                {indentString("Unicorns\nRainbows", 4, { indent: "♥" })}
              </Typography> */}
                  <UpVersionInfo />
                  <Routes>
                    <Route path="" element={<Home />} />
                    <Route path="Settings" element={<Settings />} />
                    <Route path="SettingsTime" element={<SettingsTime />} />
                    <Route path="*" element={<Home />} />
                  </Routes>
                </Box>
              </Container>
            </Router>{" "}
          </ThemeProvider>
        </HomeContextProvider>
      </LocalizationProvider>
    </LoggingContextProvider>
  );
}
