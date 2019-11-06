const CITIZENS_INITIAL_STATE = {
  citizenList: [],
  citizen: { address: { city: {} } },
  sexes: [],
  states: [],
  cities: [],
  loading: false,
  error: false,
};

function updateCitizen(state, field, value) {
  const newState = { ...state }
  newState.citizen[field] = value
  return newState
}

function updateCitizenAddress(state, field, value) {
  const newState = { ...state }
  newState.citizen.address[field] = value
  return newState
}

function updateCitizenState(state, field, value) {
  const newState = { ...state }
  newState.citizen.address.city[field] = value
  return newState
}

export const pages = (state = CITIZENS_INITIAL_STATE, action) => {
  switch (action.type) {
    case 'LOAD_CITIZENS':
      return { ...state, loading: true }
    case 'LOAD_CITIZEN_BY_ID':
      return { ...state, loading: true }
    case 'GET_CITIZENS_LIST_SUCCESS':
      return { ...state, citizenList: action.payload, loading: false }
    case 'GET_SEXES_LIST_SUCCESS':
      return { ...state, sexes: action.payload, loading: false, error: false }
    case 'GET_STATES_LIST_SUCCESS':
      return { ...state, states: action.payload, loading: false, error: false }
    case 'GET_CITIES_LIST_SUCCESS':
      return { ...state, cities: action.payload, loading: false, error: false }
    case 'GET_CITIZEN_BY_ID_SUCCESS':
      return { ...state, citizen: action.payload, loading: false, error: false }
    case 'DELETE_CITIZEN_SUCCESS':
      return { ...state, citizenList: state.citizenList.filter(citizen => citizen.id !== action.removeById), loading: false, error: false }
    case 'UPDATE_CITIZEN_SUCCESS':
      return { ...state, loading: false, error: false }
    case 'SAVE_CITIZEN_SUCCESS':
      return { ...state, loading: false, error: false }
    case 'CLEAN_CITIZEN':
      return { ...state, citizen: { address: { city: {} } } }
    case 'FETCH_FAILED':
      return { ...state, loading: false, error: true }
    case 'UPDATE_NAME':
      return updateCitizen(state, 'name', action.name)
    case 'UPDATE_CPF':
      return updateCitizen(state, 'cpf', action.cpf)
    case 'UPDATE_RG':
      return updateCitizen(state, 'rg', action.rg)
    case 'UPDATE_TELEPHONE':
      return updateCitizen(state, 'telephone', action.telephone)
    case 'UPDATE_MOBILE':
      return updateCitizen(state, 'mobile', action.mobile)
    case 'UPDATE_BIRTHDATE':
      return updateCitizen(state, 'birthDate', action.birthDate)
    case 'UPDATE_SEXID':
      return updateCitizen(state, 'sexId', action.sexId)
    case 'UPDATE_ADDRESSDESCRIPTION':
      return updateCitizenAddress(state, 'addressDescription', action.addressDescription)
    case 'UPDATE_NUMBER':
      return updateCitizenAddress(state, 'number', action.number)
    case 'UPDATE_COMPLEMENT':
      return updateCitizenAddress(state, 'complement', action.complement)
    case 'UPDATE_CEP':
      return updateCitizenAddress(state, 'cep', action.cep)
    case 'UPDATE_NEIGHBORHOOD':
      return updateCitizenAddress(state, 'neighborhood', action.neighborhood)
    case 'UPDATE_CITYID':
      return updateCitizenAddress(state, 'cityId', action.cityId)
    case 'UPDATE_STATEID':
      return updateCitizenState(state, 'stateId', action.stateId)
    default:
      return state;
  }
};

