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

export default function AddressForm() {
  const classes = useStyles();

  const address = useSelector(state => state.pages.citizen.address);
  const states = useSelector(state => state.pages.states);
  const cities = useSelector(state => state.pages.cities);
  const dispatch = useDispatch();

  const [addressDescription, setAddressDescription] = useState();
  const [number, setNumber] = useState();
  const [complement, setComplement] = useState();
  const [cep, setCep] = useState();
  const [neighborhood, setNeighborhood] = useState();
  const [stateId, setStateId] = useState();
  const [cityId, setCityId] = useState();

  useEffect(() => {
    dispatch(Actions.loadStates());
  }, []);

  useEffect(() => {
    if (address.city.stateId) {
      dispatch(Actions.loadCities(address.city.stateId));
    }
  }, [stateId]);

  useEffect(() => {
    setAddressDescription(address.addressDescription);
    setNumber(address.number);
    setComplement(address.complement);
    setCep(address.cep);
    setNeighborhood(address.neighborhood);
    setStateId(address.city.stateId);
    setCityId(address.cityId);
  });

  return (
    <React.Fragment>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <TextField
            required
            id="address"
            name="address"
            label="Endereço"
            fullWidth
            value={addressDescription || ""}
            onChange={event =>
              dispatch(Actions.updateAddressDescription(event.target.value))
            }
          />
        </Grid>
        <Grid item xs={12} md={3}>
          <TextField
            required
            id="city"
            name="city"
            label="Numero"
            fullWidth
            value={number || ""}
            onChange={event =>
              dispatch(Actions.updateNumber(event.target.value))
            }
          />
        </Grid>
        <Grid item xs={12} md={9}>
          <TextField
            id="city"
            name="city"
            label="Complemento"
            fullWidth
            value={complement || ""}
            onChange={event =>
              dispatch(Actions.updateComplement(event.target.value))
            }
          />
        </Grid>
        <Grid item xs={12} sm={4}>
          <TextField
            required
            id="zip"
            name="zip"
            label="CEP"
            fullWidth
            value={cep || ""}
            onChange={event => dispatch(Actions.updateCep(event.target.value))}
          />
        </Grid>
        <Grid item xs={12} md={8}>
          <TextField
            required
            id="neighborhood"
            name="neighborhood"
            label="Bairro"
            fullWidth
            value={neighborhood || ""}
            onChange={event =>
              dispatch(Actions.updateNeighborhood(event.target.value))
            }
          />
        </Grid>

        <Grid item xs={12} md={6}>
          <FormControl className={classes.formControl}>
            <InputLabel id="stateId">Estado</InputLabel>
            <Select
              required
              id="stateId"
              value={stateId || ""}
              onChange={event =>
                dispatch(Actions.updateStateId(event.target.value))
              }
            >
              {states.map(state => (
                <MenuItem key={state.id} value={state.id}>
                  {state.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>

        <Grid item xs={12} md={6}>
          <FormControl className={classes.formControl}>
            <InputLabel id="cityId">Cidade</InputLabel>
            <Select
              required
              id="cityId"
              value={cityId || ""}
              onChange={event =>
                dispatch(Actions.updateCityId(event.target.value))
              }
            >
              {cities.map(city => (
                <MenuItem key={city.id} value={city.id}>
                  {city.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
      </Grid>
    </React.Fragment>
  );
}
