import { makeStyles } from "@material-ui/core/styles";
import { useHistory } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import * as Actions from "../../actions/index";
import AddressForm from "./AddressForm";
import ArrowBackIcon from "@material-ui/icons/ArrowBack";
import Box from "@material-ui/core/Box";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import DeleteButton from "../Buttons/Delete";
import Fab from "@material-ui/core/Fab";
import Paper from "@material-ui/core/Paper";
import PersonForm from "./PersonForm";
import React from "react";
import Step from "@material-ui/core/Step";
import StepLabel from "@material-ui/core/StepLabel";
import Stepper from "@material-ui/core/Stepper";
import Typography from "@material-ui/core/Typography";

const useStyles = makeStyles(theme => ({
  layout: {
    width: "auto",
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    [theme.breakpoints.up(600 + theme.spacing(2) * 2)]: {
      width: 600,
      marginLeft: "auto",
      marginRight: "auto"
    }
  },
  paper: {
    marginTop: theme.spacing(3),
    marginBottom: theme.spacing(3),
    padding: theme.spacing(2),
    [theme.breakpoints.up(600 + theme.spacing(3) * 2)]: {
      marginTop: theme.spacing(6),
      marginBottom: theme.spacing(6),
      padding: theme.spacing(3)
    }
  },
  stepper: {
    padding: theme.spacing(3, 0, 5)
  },
  buttons: {
    display: "flex",
    justifyContent: "flex-end",
    marginTop: theme.spacing(3)
  },
  button: {
    margin: theme.spacing(1),
    marginTop: theme.spacing(2)
  },
  return: {
    right: theme.spacing(11)
  }
}));

const steps = ["Dados Pessoais", "Endereço"];

function getStepContent(step) {
  switch (step) {
    case 0:
      return <PersonForm />;
    case 1:
      return <AddressForm />;
    default:
      throw new Error("Unknown step");
  }
}

export default function Steps() {
  const classes = useStyles();
  let history = useHistory();
  const citizen = useSelector(state => state.pages.citizen);
  const dispatch = useDispatch();
  const [activeStep, setActiveStep] = React.useState(0);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (activeStep === 1) {
      if (!!citizen.id) {
        dispatch(Actions.updateCitizen(ajustCitizenToSave(citizen)));
      } else {
        dispatch(Actions.saveCitizen(ajustCitizenToSave(citizen)));
      }
    }
    setActiveStep(activeStep + 1);
  };

  const ajustCitizenToSave = (citizen) => {
    return { ...citizen, address: { ...citizen.address, city: null }}
  }

  const handleBack = () => {
    setActiveStep(activeStep - 1);
  };

  const handleCitizensClick = () => {
    history.push("/citizens");
  };

  return (
    <React.Fragment>
      <CssBaseline />
      <main className={classes.layout}>
        <Paper className={classes.paper}>
          <Typography component="h1" variant="h4" align="center">
            {activeStep < steps.length && (
              <Fab
                color="primary"
                className={classes.return}
                size="small"
                onClick={handleCitizensClick}
              >
                <ArrowBackIcon />
              </Fab>
            )}
            Cadastro de Pessoas
          </Typography>
          <Stepper activeStep={activeStep} className={classes.stepper}>
            {steps.map(label => (
              <Step key={label}>
                <StepLabel>{label}</StepLabel>
              </Step>
            ))}
          </Stepper>
          <React.Fragment>
            <form autoComplete="off" onSubmit={handleSubmit}>
              {activeStep === steps.length ? (
                <React.Fragment>
                  <Typography variant="h5" gutterBottom align="center">
                    {citizen.name} salvo com sucesso!
                  </Typography>
                  <Typography variant="subtitle1" align="center">
                    Este foi um CRUD simples utilizando React com Redux Saga
                  </Typography>
                  <Typography align="center">
                    <Button
                      variant="contained"
                      className={classes.button}
                      onClick={handleCitizensClick}
                      >
                      Voltar para a lista de pessoas
                    </Button>
                  </Typography>
                </React.Fragment>
              ) : (
                <React.Fragment>
                  {getStepContent(activeStep)}
                  <Box className={classes.buttons}>
                    {!!citizen.id && (
                      <DeleteButton
                      citizenId={citizen.id}
                      citizenName={citizen.name}
                      className={classes.button}
                      />
                    )}
                    {activeStep !== 0 && (
                      <Button onClick={handleBack} className={classes.button}>
                        Voltar
                      </Button>
                    )}
                    <Button
                      variant="contained"
                      color="primary"
                      type="submit"
                      className={classes.button}
                    >
                      {activeStep === steps.length - 1 ? "Salvar" : "Próximo"}
                    </Button>
                  </Box>
                </React.Fragment>
              )}
            </form>
          </React.Fragment>
        </Paper>
      </main>
    </React.Fragment>
  );
}
