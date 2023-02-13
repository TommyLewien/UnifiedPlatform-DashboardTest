import React, { useState, useEffect } from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import SvgIcon, { SvgIconProps } from "@mui/material/SvgIcon";
import Typography from "@mui/material/Typography";
import {
  getProjectInfo,
  IHomeContext,
  useHomeContext,
  useLoggingContext,
} from "discom-project";

import { VersionDTO, useUpApiQuery } from "discom-up-base";

function LightBulbIcon(props: SvgIconProps) {
  return (
    <SvgIcon {...props}>
      <path d="M9 21c0 .55.45 1 1 1h4c.55 0 1-.45 1-1v-1H9v1zm3-19C8.14 2 5 5.14 5 9c0 2.38 1.19 4.47 3 5.74V17c0 .55.45 1 1 1h6c.55 0 1-.45 1-1v-2.26c1.81-1.27 3-3.36 3-5.74 0-3.86-3.14-7-7-7zm2.85 11.1l-.85.6V16h-4v-2.3l-.85-.6C7.8 12.16 7 10.63 7 9c0-2.76 2.24-5 5-5s5 2.24 5 5c0 1.63-.8 3.16-2.15 4.1z" />
    </SvgIcon>
  );
}

export function UpVersionInfo() {
  const hc = useHomeContext();
  const lc = useLoggingContext();

  const [upWebVersion, upvIsLoading, upvIsError] = useUpApiQuery<
    string,
    VersionDTO
  >("ProjectInfo/VersionUpWebApi", {
    major: 0,
    minor: 0,
    patch: 0,
  } as VersionDTO);

  const [upDashVersion, dashIsLoading, dashIsError] = useUpApiQuery<
    string,
    VersionDTO
  >("ProjectInfo/VersionUpDashApi", {
    major: 0,
    minor: 0,
    patch: 0,
  } as VersionDTO);

  return (
    <List>
      <ListItem>
        <Typography sx={{ mt: 1, mb: 1 }} color="text.secondary">
          <LightBulbIcon sx={{ mr: 1, verticalAlign: "middle" }} />
          UpWebVersion: {upWebVersion.major}.{upWebVersion.minor}.
          {upWebVersion.patch}
        </Typography>
      </ListItem>
      <ListItem>
        <Typography sx={{ mt: 1, mb: 1 }} color="text.secondary">
          <LightBulbIcon sx={{ mr: 1, verticalAlign: "middle" }} />
          UpDashVersion: {upDashVersion.major}.{upDashVersion.minor}.
          {upDashVersion.patch}
        </Typography>
      </ListItem>
    </List>
  );
}
