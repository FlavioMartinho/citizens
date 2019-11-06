import { makeStyles } from "@material-ui/core/styles";
import { useHistory } from "react-router-dom";
import EditIcon from "@material-ui/icons/Edit";
import Fab from "@material-ui/core/Fab";
import React from "react";

const useStyles = makeStyles(theme => ({
  fab: {
    margin: theme.spacing(1),
    marginTop: theme.spacing(2)
  }
}));

export default function EditButton({ citizenId }) {
  const classes = useStyles();
  let history = useHistory();

  const handleEdit = () => {
    history.push(`/citizen/${citizenId}`);
  };

  return (
    <div>
      <Fab
        color="primary"
        size="small"
        className={classes.fab}
        onClick={handleEdit}
      >
        <EditIcon />
      </Fab>
    </div>
  );
}
