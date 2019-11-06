import { createMuiTheme } from "@material-ui/core/styles";
import { createStore, applyMiddleware, combineReducers } from "redux";
import { pages } from "../reducers";
import { Provider } from "react-redux";
import { Router, Route, Switch } from "react-router";
import { routerReducer } from "react-router-redux";
import { ThemeProvider } from "@material-ui/core/styles";
import Citizen from "../pages/Citizen";
import CitizenList from "../pages/CitizenList";
import createHistory from "history/createBrowserHistory";
import createSagaMiddleware from "redux-saga";
import Header from "../components/Header";
import React, { useEffect } from "react";
import rootSaga from "../sagas";

const history = createHistory();
const sagaMiddleware = createSagaMiddleware();
const store = createStore(
  combineReducers({
    pages,
    routing: routerReducer
  }),
  applyMiddleware(sagaMiddleware)
);

sagaMiddleware.run(rootSaga);

export default AppRoutes = () => {
  const theme = createMuiTheme({
    palette: {
      primary: {
        main: "#565656"
      },
      secondary: {
        main: "#ea3a3a"
      }
    }
  });

  useEffect(() => {
    if (history.location.pathname === "/") {
      history.push("/citizens");
    }
  }, []);

  return (
    <ThemeProvider theme={theme}>
      <Provider store={store}>
        <Header />
        <Router history={history}>
          <Switch>
            <Route path="/citizen/:citizenId?" component={Citizen} />
            <Route path="/citizens" exact strict component={CitizenList} />
          </Switch>
        </Router>
      </Provider>
    </ThemeProvider>
  );
};
