import * as React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import Link from "@mui/material/Link";
import CssBaseline from "@mui/material/CssBaseline";
import { ThemeProvider, createTheme } from "@mui/material/styles";

import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import Preferences from "./Preference";

import Button from "@mui/material/Button";

import { themeLight, themeDark } from "../style/theme";
import { MiniDrawer } from "./TsSideMenu";
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
import { defaultIsLightTheme, defaultLocale } from "./PreferenceModel";

const localeMap: any = {
  en: enLocale,
  de: deLocale,
};

const application = "UpTestReact";
const defUserId = "Discom";
const defSessionId = "Std";

export default function App() {
  document.title = "UpTestReact";
  // loadIdContext will lookup cookies and suppy defaults to userId and SessionId
  const idc: IdContext = loadIdContext(application);

  const [isLightTheme, setLight] = React.useState(
    defaultIsLightTheme(application, defUserId)
  );
  // const [light, setLight] = React.useState(true);
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
          <ThemeProvider theme={isLightTheme ? themeLight : themeDark}>
            <Router basename={navBaseName}>
              <CssBaseline />
              <MiniDrawer
                preferenceComp={
                  // <div />
                  <Preferences
                    locale={locale}
                    setLocale={setLocale}
                    isLightTheme={isLightTheme}
                    setThemeLight={setLight}
                  />
                }
              >
                <Box
                  sx={{
                    marginRight: "30px",
                  }}
                >
                  <UpVersionInfo />
                  <Routes>
                    <Route path="" element={<Home />} />
                    <Route path="Settings" element={<Settings />} />
                    <Route path="SettingsTime" element={<SettingsTime />} />
                    <Route path="*" element={<Home />} />
                  </Routes>
                </Box>
                {/* </div> */}
              </MiniDrawer>
            </Router>{" "}
          </ThemeProvider>
        </HomeContextProvider>
      </LocalizationProvider>
    </LoggingContextProvider>
  );
}
