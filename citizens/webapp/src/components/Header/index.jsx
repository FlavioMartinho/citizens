import { makeStyles } from "@material-ui/styles";
import AppBar from "@material-ui/core/AppBar";
import CssBaseline from "@material-ui/core/CssBaseline";
import React, { Component } from "react";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";

export default class Header extends Component {
  useStyles() {
    return makeStyles(theme => ({
      appBar: {
        position: "relative"
      }
    }));
  }

  render() {
    const classes = this.useStyles();
    return (
      <React.Fragment>
        <CssBaseline />
        <AppBar position="relative" color="default" className={classes.appBar}>
          <Toolbar>
            <Typography variant="h6" color="inherit" noWrap>
              Citizens
            </Typography>
          </Toolbar>
        </AppBar>
      </React.Fragment>
    );
  }
}
