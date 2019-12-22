FROM mongo:3.4-xenial

COPY /./BirdsData /var/lib/mongodb/

RUN chown -R mongodb:mongodb /var/lib/mongodb/

