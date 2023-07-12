FROM ubuntu:22.04

RUN apt-get update && apt-get install -y dotnet7 ca-certificates

# args
ARG name_project=RedocPro

# files
WORKDIR /app
COPY . .

# dotnet
RUN dotnet tool install --global dotnet-dev-certs
RUN dotnet dev-certs https --clean && dotnet dev-certs https -ep /https/aspnetapp.pfx -p password --trust
RUN dotnet restore
RUN dotnet build --configuration Debug

# node js
RUN apt-get install -y nodejs
RUN apt-get install -y npm
RUN npm install -g redoc-cli@latest
RUN npm install -g openapi-to-postmanv2


# Install Cron
RUN apt-get update -qq && apt-get -y install cron -qq --force-yes

# Add export environment variable script and schedule
COPY *.sh ./
COPY schedule /etc/cron.d/schedule
RUN sed -i 's/\r//' export_env.sh \
    && sed -i 's/\r//' run_app.sh \
    && sed -i 's/\r//' /etc/cron.d/schedule \
    && chmod +x export_env.sh run_app.sh \
    && chmod 0644 /etc/cron.d/schedule

# Create log file
RUN touch /var/log/cron.log
RUN chmod 0666 /var/log/cron.log

# Volume required for tail command
VOLUME /var/log

# Run Cron
CMD /app/export_env.sh && /usr/sbin/cron && tail -f /var/log/cron.log