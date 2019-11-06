import { makeStyles } from "@material-ui/core/styles";
import { useSelector, useDispatch } from "react-redux";
import * as Actions from "../../../actions/index";
import FormControl from "@material-ui/core/FormControl";
import Grid from "@material-ui/core/Grid";
import InputLabel from "@material-ui/core/InputLabel";
import MenuItem from "@material-ui/core/MenuItem";
import React, { useState, useEffect } from "react";
import Select from "@material-ui/core/Select";
import TextField from "@material-ui/core/TextField";

const useStyles = makeStyles(theme => ({
  container: {
    display: "flex",
    flexWrap: "wrap"
  },
  textField: {
    marginLeft: theme.spacing(1),
    marginRight: theme.spacing(1),
    width: 200
  },
  formControl: {
    minWidth: 150,
    maxWidth: 200
  }
}));

export default function PersonForm() {
  const classes = useStyles();

  const citizen = useSelector(state => state.pages.citizen);
  const sexes = useSelector(state => state.pages.sexes);
  const dispatch = useDispatch();

  const [name, setName] = useState();
  const [cpf, setCpf] = useState();
  const [rg, setRg] = useState();
  const [telephone, setTelephone] = useState();
  const [mobile, setMobile] = useState();
  const [birthDate, setBirthDate] = useState();
  const [sexId, setSexId] = useState();

  useEffect(() => {
    dispatch(Actions.loadSexes());
  }, []);

  useEffect(() => {
    setName(citizen.name);
    setCpf(citizen.cpf);
    setRg(citizen.rg);
    setTelephone(citizen.telephone);
    setMobile(citizen.mobile);
    setBirthDate(citizen.birthDate);
    setSexId(citizen.sexId);
  });

  return (
    <React.Fragment>
      <Grid container spacing={3}>
        <Grid item xs={12} md={12}>
          <TextField
            required
            id="name"
            name="name"
            label="Nome Completo"
            fullWidth
            value={name || ""}
            onChange={event => dispatch(Actions.updateName(event.target.value))}
          />
        </Grid>

        <Grid item xs={12} md={6}>
          <TextField
            required
            id="cpf"
            name="cpf"
            label="CPF"
            fullWidth
            value={cpf || ""}
            onChange={event => dispatch(Actions.updateCpf(event.target.value))}
          />
        </Grid>

        <Grid item xs={12} md={6}>
          <TextField
            required
            id="rg"
            name="rg"
            label="RG"
            fullWidth
            value={rg || ""}
            onChange={event => dispatch(Actions.updateRg(event.target.value))}
          />
        </Grid>

        <Grid item xs={12} md={6}>
          <TextField
            required
            id="telephone"
            name="telephone"
            label="Telefone"
            fullWidth
            value={telephone || ""}
            onChange={event =>
              dispatch(Actions.updateTelephone(event.target.value))
            }
          />
        </Grid>

        <Grid item xs={12} md={6}>
          <TextField
            required
            id="mobile"
            name="mobile"
            label="Celular"
            fullWidth
            value={mobile || ""}
            onChange={event =>
              dispatch(Actions.updateMobile(event.target.value))
            }
          />
        </Grid>

        <Grid item xs={12} md={6}>
          <TextField
            required
            id="date"
            label="Data de Nascimento"
            type="date"
            format="dd/MM/yyyy"
            value={birthDate || ""}
            InputLabelProps={{
              shrink: true
            }}
            onChange={event =>
              dispatch(Actions.updateBirthDate(event.target.value))
            }
          />
        </Grid>
        <Grid item xs={12} md={6}>
          <FormControl className={classes.formControl}>
            <InputLabel id="sexId">Sexo</InputLabel>
            <Select
              required
              id="sexId"
              value={sexId || ""}
              onChange={event =>
                dispatch(Actions.updateSexId(event.target.value))
              }
            >
              {sexes.map(sex => (
                <MenuItem key={sex.id} value={sex.id}>
                  {sex.description}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
      </Grid>
    </React.Fragment>
  );
}
