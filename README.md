# AzureWebJobScheduler
A way to trigger the AzureLetsEncryptRenewer webjob while running on a free plan.

Azure Function Application Settings needed to configure:

* ```WebAppName```: The name of the webapp where the webjob is housed.  Typically {whatgoeshere}.azurewebsites.net.

* ```WebJobName```: The name of the webjob. This is readily accessible from the webjobs screen in the portal.

* ```WebJobUser```: If you go to the web app with the web job inside, click on webjobs, the webjob you want to trigger, then properties, a username will be presented to you to use in this app setting.

* ```WebJobPassword```: A password will be in the same place.

And that's it!  Enjoy your free webjob.
