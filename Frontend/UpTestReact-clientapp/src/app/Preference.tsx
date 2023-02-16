import React, { useState, useEffect } from "react";
import { Dispatch, SetStateAction } from "react";

import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import InputLabel from "@mui/material/InputLabel";
import FormControl from "@mui/material/FormControl";
import NativeSelect from "@mui/material/NativeSelect";

import Button from "@mui/material/Button";
import IconButton from "@mui/material/IconButton";
import WbSunnyIcon from "@mui/icons-material/WbSunny";
import NightsStayIcon from "@mui/icons-material/NightsStay";

import { useTranslation } from "react-i18next";

import { useSerializationContext, useLoggingContext } from "discom-project";

import { loadPreferenceData, storePreferenceData } from "./PreferenceModel";

interface PrefProps {
  locale: string;
  setLocale: Dispatch<SetStateAction<string>>;
  isLightTheme: boolean;
  setThemeLight: Dispatch<SetStateAction<boolean>>;
}

export default function Preferences({
  locale,
  setLocale,
  isLightTheme,
  setThemeLight,
}: PrefProps) {
  const lc = useLoggingContext();
  const sc = useSerializationContext();
  const { t, i18n } = useTranslation();

  // load preference data when the serialization context changes, which it does in the init phase
  // if there are no preferences yet under this sc, store the current settings
  useEffect(() => {
    loadPreferenceData(
      { locale, isLightTheme },
      setLocale,
      setThemeLight,
      sc,
      lc
    );
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [sc]);

  return (
    // <Box sx={{ width: 150, background: "yellow" }}>
    <Box sx={{ color: "#dfdee2", width: 120 }}>
      <IconButton
        color="inherit"
        onClick={() => {
          // this nice line does not update theme on the fly, so locale is still old
          // setThemeLight((prev) => !prev);
          const newIsLightTheme: boolean = !isLightTheme;
          storePreferenceData(
            { locale, isLightTheme: newIsLightTheme },
            sc,
            lc
          );
          setThemeLight(newIsLightTheme);
        }}
        edge="start"
      >
        {isLightTheme ? (
          <WbSunnyIcon fontSize="small" />
        ) : (
          <NightsStayIcon fontSize="small" />
        )}
      </IconButton>
      <FormControl>
        <NativeSelect
          value={locale}
          inputProps={{
            name: "language",
            id: "uncontrolled-native",
          }}
          onChange={(event) => {
            setLocale(event.target.value);
            storePreferenceData(
              { locale: event.target.value, isLightTheme },
              sc,
              lc
            );
          }}
        >
          <option value={"en"}>English</option>
          <option value={"de"}>Deutsch</option>
          <option value={"zh"}>中文</option>
        </NativeSelect>
      </FormControl>
    </Box>
  );
}
