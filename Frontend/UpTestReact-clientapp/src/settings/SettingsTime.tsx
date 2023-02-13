import * as React from "react";
import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";

import ToggleButton from "@mui/material/ToggleButton";
import ToggleButtonGroup from "@mui/material/ToggleButtonGroup";
import TextField from "@mui/material/TextField";

//import TimePicker from "@mui/x-date-pickers/TimePicker";

export default function SettingsTime() {
  const [value, setValue] = React.useState(new Date());
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: { xs: "column", md: "row" },
        alignItems: "center",
        // bgcolor: "orange",
        overflow: "hidden",
        borderRadius: "12px",
        boxShadow: 1,
        fontWeight: "bold",
        marginRight: "1px",
        marginLeft: "1px",
      }}
    >
      <Typography variant="h4" component="h1" gutterBottom>
        Time
      </Typography>

      {/* <TimePicker
        value={value}
        // onChange={(newValue) => setValue(newValue ? newValue : new Date())}
        // renderInput={(params) => <TextField {...params} />}
      /> */}
    </Box>
  );
}
