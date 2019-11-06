export const cleanCitizen = () => ({
  type: 'CLEAN_CITIZEN'
})

export const loadSexes = () => ({
  type: 'LOAD_SEXES'
})

export const loadStates = () => ({
  type: 'LOAD_STATES'
})

export const loadCities = (id) => ({
  type: 'LOAD_CITIES',
  id
})

export const loadCitizens = () => ({
  type: 'LOAD_CITIZENS'
})

export const loadCitizenById = (id) => ({
  type: 'LOAD_CITIZEN_BY_ID',
  id
})

export const updateName = (name) => ({
  type: 'UPDATE_NAME',
  name
})

export const updateCpf = (cpf) => ({
  type: 'UPDATE_CPF',
  cpf
})

export const updateRg = (rg) => ({
  type: 'UPDATE_RG',
  rg
})

export const updateTelephone = (telephone) => ({
  type: 'UPDATE_TELEPHONE',
  telephone
})

export const updateMobile = (mobile) => ({
  type: 'UPDATE_MOBILE',
  mobile
})

export const updateBirthDate = (birthDate) => ({
  type: 'UPDATE_BIRTHDATE',
  birthDate
})

export const updateSexId = (sexId) => ({
  type: 'UPDATE_SEXID',
  sexId
})

export const updateAddressDescription = (addressDescription) => ({
  type: 'UPDATE_ADDRESSDESCRIPTION',
  addressDescription
})

export const updateNumber = (number) => ({
  type: 'UPDATE_NUMBER',
  number
})

export const updateComplement = (complement) => ({
  type: 'UPDATE_COMPLEMENT',
  complement
})

export const updateCep = (cep) => ({
  type: 'UPDATE_CEP',
  cep
})

export const updateNeighborhood = (neighborhood) => ({
  type: 'UPDATE_NEIGHBORHOOD',
  neighborhood
})

export const updateCityId = (cityId) => ({
  type: 'UPDATE_CITYID',
  cityId
})

export const updateStateId = (stateId) => ({
  type: 'UPDATE_STATEID',
  stateId
})

export const deleteCitizen = (id) => ({
  type: 'DELETE_CITIZEN',
  id
})

export const updateCitizen = (citizen) => ({
  type: 'UPDATE_CITIZEN',
  citizen
})

export const saveCitizen = (citizen) => ({
  type: 'SAVE_CITIZEN',
  citizen
})
