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
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import ExpandLessIcon from "@mui/icons-material/ExpandLess";
import MenuOpenIcon from "@mui/icons-material/MenuOpen";

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
import useMediaQuery from "@mui/material/useMediaQuery";

import { Theme } from "@mui/material/styles";
import { Grid, SvgIcon } from "@mui/material";

const expandedDrawerWidth = 220;

const openedMixin = (theme: Theme) => ({
  width: expandedDrawerWidth,
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
    width: `calc(${theme.spacing(7)} + 1px)`,
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
    marginLeft: expandedDrawerWidth,
    width: `calc(100% - ${expandedDrawerWidth}px)`,
    transition: theme.transitions.create(["width", "margin"], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

const Drawer = styled(MuiDrawer, {
  shouldForwardProp: (prop) => prop !== "open",
})(({ theme, open }: { theme: Theme; open?: boolean }) => ({
  width: expandedDrawerWidth,
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

enum eUserIconsDisplayState {
  doesNotCare,
  wantsItOpen,
  wantsItClosed,
}

enum eDrawerState {
  iconMenu,
  fullMenu,
  hidden,
}

interface ParentPreferenceCompProps {
  preferenceComp?: React.ReactNode;
  statusComp?: React.ReactNode;
  children?: React.ReactNode;
}

export const MiniDrawer: React.FC<ParentPreferenceCompProps> = ({
  preferenceComp,
  statusComp,
  children,
}) => {
  const theme = useTheme();
  const [openFullText, setOpenFullText] = React.useState(false);
  const [openIcons, setOpenIcons] = React.useState(true);
  const [userIconDrawerDisplayState, setUserIconDrawerDisplayState] =
    React.useState(eUserIconsDisplayState.doesNotCare);
  const displayIconDrawerSizewise = useMediaQuery(theme.breakpoints.up("sm"));

  const handleDrawerOpen = () => {
    setOpenFullText(true);
  };

  const handleDrawerClose = () => {
    setOpenFullText(false);
  };

  const drawerState: eDrawerState =
    displayIconDrawerSizewise && openFullText
      ? // large enough to display icon drawer and in openFulltext Mode:
        eDrawerState.fullMenu
      : displayIconDrawerSizewise && !openFullText
      ? // large enough to display icons and not commanded to full text
        eDrawerState.iconMenu
      : !displayIconDrawerSizewise &&
        (userIconDrawerDisplayState === eUserIconsDisplayState.doesNotCare ||
          userIconDrawerDisplayState === eUserIconsDisplayState.wantsItClosed)
      ? // too small to display filter and not commanded to different or commanded to be closed:
        eDrawerState.hidden
      : !displayIconDrawerSizewise &&
        userIconDrawerDisplayState === eUserIconsDisplayState.wantsItOpen
      ? // too small to display filter but commanded to be open. command overides
        eDrawerState.iconMenu
      : // else show only content -- should not happen
        eDrawerState.iconMenu;

  const handleDrawerDisplayChange = () => {
    if (displayIconDrawerSizewise) {
      // large enough to open iconDrawer
      if (drawerState === eDrawerState.fullMenu) {
        setOpenFullText(false);
      } else if (drawerState === eDrawerState.iconMenu) {
        setOpenFullText(true);
      }
    } else {
      // too small for iconDrawer
      if (drawerState === eDrawerState.iconMenu) {
        setUserIconDrawerDisplayState(eUserIconsDisplayState.wantsItClosed);
      } else {
        setUserIconDrawerDisplayState(eUserIconsDisplayState.wantsItOpen);
      }
    }
  };

  // capital D ! to be recognized
  const DrawerIcon: typeof SvgIcon =
    drawerState === eDrawerState.iconMenu && displayIconDrawerSizewise
      ? MenuIcon
      : drawerState === eDrawerState.iconMenu && !displayIconDrawerSizewise
      ? ExpandLessIcon
      : drawerState === eDrawerState.fullMenu
      ? MenuOpenIcon
      : drawerState === eDrawerState.hidden
      ? ExpandMoreIcon
      : MenuIcon;

  return (
    <div>
      <AppBar position="fixed" theme={theme}>
        <Toolbar sx={{ display: "flex" }}>
          <Grid container spacing={1} alignItems={"center"}>
            <Grid item xs={1}>
              <IconButton
                color="inherit"
                aria-label="open drawer"
                onClick={handleDrawerDisplayChange}
                edge="start"
              >
                <DrawerIcon />
              </IconButton>
            </Grid>
            <Grid item xs sx={{ display: { xs: "none", sm: "block" } }}>
              <Typography
                variant="h6"
                color="textSecondary"
                //sx={{ textDecoration: "none" }}
                noWrap
                component={RouterLink}
                to="Home"
              >
                Discom WebDash
              </Typography>
            </Grid>
            <Grid item xs sx={{ display: { xs: "block", sm: "none" } }}>
              <Typography
                variant="h6"
                color="textSecondary"
                // sx={{ textDecoration: "none" }}
                noWrap
                component={RouterLink}
                to="Home"
              >
                WebDash
              </Typography>
            </Grid>
            <Grid item xs>
              <Grid container justifyContent="right">
                {preferenceComp}
              </Grid>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>
      <Drawer
        variant="permanent"
        theme={theme}
        open={openFullText}
        sx={{
          width: "0",
          ...(drawerState === eDrawerState.hidden && { display: "none" }),
        }}
      >
        <DrawerHeader />
        {/* The div  isolates the box below, otherwise it always clings to the
        right side */}
        {/* <div style={{ width: "100%" }}>
            <Box
              display="flex"
              m={0}
              // sx={{ background: "green" }}
            ></Box>
          </div>
        </DrawerHeader> */}
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
      {/* Use a auto box to extend the children 
       for xs, no margins around the browser window
       for sm, margin 1 to right and depending on drawer state 0 or 8 to the left */}
      <Box
        sx={{
          width: "auto",
          marginInlineEnd: { xs: 0, sm: 1 },
        }}
      >
        {/*  Shift down the content with an empty DrawerHeader:
          https://stackoverflow.com/questions/48508449/content-beneath-fixed-appbar
          */}
        <DrawerHeader />
        <Box
          marginLeft={drawerState === eDrawerState.hidden ? 0 : 10}
          marginTop={0}
          // sx={{ background: "green" }}
        >
          {children}
        </Box>
      </Box>
    </div>
  );
};
