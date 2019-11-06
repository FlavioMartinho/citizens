import axios from 'axios'

const api = axios.create({
  mode: 'cors',
  baseURL: 'http://localhost:5000/api',
})

export function getSexesApi() {
  return api.get('/sexes')
    .then(resp => resp)
}

export function getStatesApi() {
  return api.get('/states')
    .then(resp => resp)
}

export function getCitiesApi(id) {
  return api.get(`/cities/${id}`)
    .then(resp => resp)
}

export function getCitizensApi() {
  return api.get('/citizens')
    .then(resp => resp)
}

export function getCitizenByIdApi(id) {
  return api.get(`/citizen/${id}`)
    .then(resp => resp)
}

export function deleteCitizenApi(id) {
  return api.delete(`/citizen/${id}`)
    .then(resp => resp)
}

export function updateCitizenApi(citizen) {
  return api.put(`/citizen/${citizen.id}`, citizen)
    .then(resp => resp)
}

export function saveCitizenApi(citizen) {
  return api.post('/citizen', citizen)
    .then(resp => resp)
}
