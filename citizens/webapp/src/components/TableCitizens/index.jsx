import { makeStyles } from "@material-ui/core/styles";
import AddButton from "../Buttons/Add";
import Box from "@material-ui/core/Box";
import DeleteButton from "../Buttons/Delete";
import EditButton from "../Buttons/Edit";
import Paper from "@material-ui/core/Paper";
import React from "react";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";

const useStyles = makeStyles(theme => ({
  root: {
    overflowX: "auto",
    marginTop: "30px",
    marginLeft: "30px",
    marginRight: "30px"
  },
  table: {
    minWidth: 650
  },
  tableHead: {
    paddingTop: "0px",
    paddingBottom: "0px",
    paddingLeft: "16px",
    paddingRight: "16px"
  },
  tableHeadRow: {
    backgroundColor: "#e6e6e6"
  },
}));

export default function TableCitizens({ citizenList }) {
  const classes = useStyles();

  return (
    <Paper className={classes.root}>
      <Table className={classes.table} aria-label="simple table">
        <TableHead>
          <TableRow className={classes.tableHeadRow}>
            <TableCell className={classes.tableHead}>Nome</TableCell>
            <TableCell className={classes.tableHead} align="left">
              Data de Nascimento
            </TableCell>
            <TableCell className={classes.tableHead} align="left">
              Celular
            </TableCell>
            <TableCell className={classes.tableHead} align="left">
              RG
            </TableCell>
            <TableCell className={classes.tableHead} align="left">
              Bairro
            </TableCell>
            <TableCell className={classes.tableHead} align="left">
              Cidade
            </TableCell>
            <TableCell className={classes.tableHead} align="left">
              Estado
            </TableCell>
            <TableCell className={classes.tableHead} align="left">
              <AddButton />
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {citizenList.map(citizen => (
            <TableRow key={citizen.name}>
              <TableCell component="th" scope="roow">
                {citizen.name}
              </TableCell>
              <TableCell align="left">{citizen.birthDate}</TableCell>
              <TableCell align="left">{citizen.mobile}</TableCell>
              <TableCell align="left">{citizen.rg}</TableCell>
              <TableCell align="left">{citizen.address.neighborhood}</TableCell>
              <TableCell align="left">{citizen.address.city.name}</TableCell>
              <TableCell align="left">
                {citizen.address.city.state.name}
              </TableCell>
              <TableCell align="left">
                <Box display="flex" flexDirection="row">
                  <Box>
                    <EditButton citizenId={citizen.id} />
                  </Box>
                  <Box>
                    <DeleteButton
                      citizenId={citizen.id}
                      citizenName={citizen.name}
                    />
                  </Box>
                </Box>
              </TableCell>
            </TableRow>
          ))}
          {citizenList.length === 0 && (
            <TableRow>
              <TableCell component="th" scope="roow">
                -
              </TableCell>
              <TableCell align="left">-</TableCell>
              <TableCell align="left">-</TableCell>
              <TableCell align="left">-</TableCell>
              <TableCell align="left">-</TableCell>
              <TableCell align="left">-</TableCell>
              <TableCell align="left">-</TableCell>
              <TableCell align="left">-</TableCell>
            </TableRow>
          )}
        </TableBody>
      </Table>
    </Paper>
  );
}
