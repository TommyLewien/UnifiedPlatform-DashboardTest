import * as React from "react";
import { styled, useTheme } from "@mui/material/styles";
import Box from "@mui/material/Box";
import MuiDrawer from "@mui/material/Drawer";
import MuiAppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import List from "@mui/material/List";
import CssBaseline from "@mui/material/CssBaseline";
import Typography from "@mui/material/Typography";
import Divider from "@mui/material/Divider";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";
import ChevronRightIcon from "@mui/icons-material/ChevronRight";
import ListItem from "@mui/material/ListItem";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import InboxIcon from "@mui/icons-material/MoveToInbox";
import MailIcon from "@mui/icons-material/Mail";
import SettingsIcon from "@mui/icons-material/Settings";
import HomeIcon from "@mui/icons-material/Home";
import AccessTimeIcon from "@mui/icons-material/AccessTime";
import { Route, MemoryRouter } from "react-router";
import Link from "@mui/material/Link";
import { Link as RouterLink } from "react-router-dom";

import { Theme } from "@mui/material/styles";

const drawerWidth = 240;

const openedMixin = (theme: Theme) => ({
  width: drawerWidth,
  transition: theme.transitions.create("width", {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.enteringScreen,
  }),
  overflowX: "hidden",
});

const closedMixin = (theme: Theme) => ({
  backgound: "green",
  transition: theme.transitions.create("width", {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  overflowX: "hidden",
  width: `calc(${theme.spacing(7)} + 1px)`,
  [theme.breakpoints.up("sm")]: {
    width: `calc(${theme.spacing(9)} + 1px)`,
  },
});
const DrawerHeader = styled("div")(({ theme }) => ({
  display: "flex",
  backgound: "yellow",
  alignItems: "center",
  justifyContent: "flex-end",
  padding: theme.spacing(0, 1),
  // necessary for content to be below app bar
  ...theme.mixins.toolbar,
}));

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== "open",
})(({ theme, open }: { theme: Theme; open?: boolean }) => ({
  zIndex: theme.zIndex.drawer + 1,
  color: theme.palette.secondary.contrastText,
  background: theme.palette.secondary.main,
  transition: theme.transitions.create(["width", "margin"], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  ...(open && {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(["width", "margin"], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

const Drawer = styled(MuiDrawer, {
  shouldForwardProp: (prop) => prop !== "open",
})(({ theme, open }: { theme: Theme; open?: boolean }) => ({
  width: drawerWidth,
  flexShrink: 0,
  whiteSpace: "nowrap",
  boxSizing: "border-box",
  ...(open && {
    "& .MuiDrawer-paper": openedMixin(theme),
  }),
  ...(!open && {
    "& .MuiDrawer-paper": closedMixin(theme),
  }),
}));

export default function MiniDrawer() {
  const theme = useTheme();
  const [open, setOpen] = React.useState(false);

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  const handleDrawerChange = () => {
    open ? setOpen(false) : setOpen(true);
  };

  return (
    <Box sx={{ display: "flex", background: "green" }}>
      {/* <CssBaseline /> */}
      {/* <AppBar position="fixed" theme={theme} open={open}> */}
      <AppBar position="fixed" theme={theme}>
        <Toolbar>
          <IconButton
            color="inherit"
            aria-label="open drawer"
            onClick={handleDrawerOpen}
            edge="start"
            sx={{
              marginRight: "36px",
              ...(open && { display: "none" }),
            }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" noWrap component="div">
            Discom WebDash
          </Typography>
        </Toolbar>
      </AppBar>
      <Drawer variant="permanent" theme={theme} open={open} sx={{ width: "0" }}>
        <DrawerHeader>
          {/* The div  isolates the box below, otherwise it always clings to the
        right side */}
          <div style={{ width: "100%" }}>
            <Box
              display="flex"
              m={0}
              // sx={{ background: "green" }}
            >
              <IconButton onClick={handleDrawerChange}>
                <ChevronRightIcon
                  sx={{
                    ...(open && { display: "none" }),
                  }}
                />
                <ChevronLeftIcon
                  sx={{
                    ...(!open && { display: "none" }),
                  }}
                />
              </IconButton>
            </Box>
          </div>
        </DrawerHeader>
        <Divider />

        {/* <Link component={RouterLink} to="/">
          Homing
        </Link> */}

        <List>
          <ListItem button component={RouterLink} to="Home">
            <ListItemIcon>
              <HomeIcon />
            </ListItemIcon>
            <ListItemText primary="Home" />
          </ListItem>

          <ListItem button component={RouterLink} to="SettingsTime">
            <ListItemIcon>
              <AccessTimeIcon />
            </ListItemIcon>
            <ListItemText primary="Time Selection" />
          </ListItem>

          <ListItem button component={RouterLink} to="Settings">
            <ListItemIcon>
              <SettingsIcon />
            </ListItemIcon>
            <ListItemText primary="Settings" />
          </ListItem>
        </List>
        <Divider />
        <List>
          {["All mail", "Trash", "Spam"].map((text, index) => (
            <ListItem button key={text}>
              <ListItemIcon>
                {index % 2 === 0 ? <InboxIcon /> : <MailIcon />}
              </ListItemIcon>
              <ListItemText primary={text} />
            </ListItem>
          ))}
        </List>
      </Drawer>
      {/*  SHift down the content with an empty DrawerHeader:
          https://stackoverflow.com/questions/48508449/content-beneath-fixed-appbar
          */}
      <DrawerHeader />
    </Box>
  );
}
