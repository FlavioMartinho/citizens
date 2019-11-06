FROM node:8.16-alpine as build

WORKDIR /opt/citizens-webapp-source

COPY . .

RUN npm install && npm run build

FROM nginx:latest

WORKDIR /opt/citizens-webapp

COPY --from=build /opt/citizens-webapp-source/dist /opt/citizens-webapp

RUN rm /etc/nginx/conf.d/default.conf

COPY config /etc/nginx/conf.d

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
