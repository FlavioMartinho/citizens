import { makeStyles } from "@material-ui/core/styles";
import { useHistory } from "react-router-dom";
import AddIcon from "@material-ui/icons/Add";
import Fab from "@material-ui/core/Fab";
import React from "react";

const useStyles = makeStyles(theme => ({
  fab: {
    margin: theme.spacing(1)
  }
}));

export default function AddButton() {
  const classes = useStyles();
  let history = useHistory();

  const handleAdd = () => {
    history.push("citizen");
  };

  return (
    <div>
      <Fab
        color="primary"
        size="small"
        className={classes.fab}
        onClick={handleAdd}
      >
        <AddIcon />
      </Fab>
    </div>
  );
}
