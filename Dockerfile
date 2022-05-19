FROM ubuntu

RUN apt-get update
RUN apt-get install -y wget
RUN apt-get install -y tzdata
ENV TZ=America
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

RUN		wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN		dpkg -i packages-microsoft-prod.deb
RUN		rm packages-microsoft-prod.deb
RUN	    apt-get update; \
	    apt-get install -y apt-transport-https && \
	    apt-get update && \
	    apt-get install -y dotnet-sdk-6.0
RUN	    apt-get update; \
	    apt-get install -y apt-transport-https && \
	    apt-get update && \
	    apt-get install -y aspnetcore-runtime-6.0
RUN	    apt-get install -y dotnet-runtime-6.0
EXPOSE 5171
EXPOSE 1433
RUN mkdir /api
WORKDIR /api
COPY SWTallerMecanico /api/
CMD dotnet run && tail -f /dev/null