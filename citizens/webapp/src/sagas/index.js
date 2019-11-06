import { put, takeLatest, call, all } from 'redux-saga/effects';
import { getSexesApi, getStatesApi, getCitiesApi, getCitizensApi, getCitizenByIdApi, deleteCitizenApi, updateCitizenApi, saveCitizenApi } from '../services'

function* loadSexes() {
  try {
    const request = yield call(getSexesApi);
    yield put({ type: 'GET_SEXES_LIST_SUCCESS', payload: request.data });

  } catch (error) {
    yield put({ type: 'FETCH_FAILED', error: error.message });
  }

}

function* loadStates() {
  try {
    const request = yield call(getStatesApi);
    yield put({ type: 'GET_STATES_LIST_SUCCESS', payload: request.data });

  } catch (error) {
    yield put({ type: 'FETCH_FAILED', error: error.message });
  }

}

function* loadCities({ id }) {
  try {
    const request = yield call(getCitiesApi, id);
    yield put({ type: 'GET_CITIES_LIST_SUCCESS', payload: request.data });

  } catch (error) {
    yield put({ type: 'FETCH_FAILED', error: error.message });
  }

}

function* loadCitizens() {
  try {
    const request = yield call(getCitizensApi);
    yield put({ type: 'GET_CITIZENS_LIST_SUCCESS', payload: request.data });

  } catch (error) {
    yield put({ type: 'FETCH_FAILED', error: error.message });
  }

}

function* loadCitizenById({ id }) {
  try {
    const request = yield call(getCitizenByIdApi, id);
    yield put({ type: 'GET_CITIZEN_BY_ID_SUCCESS', payload: request.data.value });

  } catch (error) {
    yield put({ type: 'FETCH_FAILED', error: error.message });
  }

}

function* deleteCitizen({ id }) {
  try {
    yield call(deleteCitizenApi, id);
    yield put({ type: 'DELETE_CITIZEN_SUCCESS', removeById: id });

  } catch (error) {
    yield put({ type: 'FETCH_FAILED', error: error.message });
  }

}

function* updateCitizen({ citizen }) {
  try {
    yield call(updateCitizenApi, citizen);
    yield put({ type: 'UPDATE_CITIZEN_SUCCESS' });

  } catch (error) {
    yield put({ type: 'FETCH_FAILED', error: error.message });
  }

}

function* saveCitizen({ citizen }) {
  try {
    yield call(saveCitizenApi, citizen);
    yield put({ type: 'SAVE_CITIZEN_SUCCESS' });

  } catch (error) {
    yield put({ type: 'FETCH_FAILED', error: error.message });
  }

}

export default function* rootSaga() {
  yield all([
    takeLatest('LOAD_SEXES', loadSexes),
    takeLatest('LOAD_STATES', loadStates),
    takeLatest('LOAD_CITIES', loadCities),
    takeLatest('LOAD_CITIZENS', loadCitizens),
    takeLatest('LOAD_CITIZEN_BY_ID', loadCitizenById),
    takeLatest('DELETE_CITIZEN', deleteCitizen),
    takeLatest('UPDATE_CITIZEN', updateCitizen),
    takeLatest('SAVE_CITIZEN', saveCitizen),
  ]);
}
