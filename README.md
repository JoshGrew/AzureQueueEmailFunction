### Azure Storage Uploader Project	

## Introduction

# PopulateQueue

.NET Core 2.1 console app that populates basic Email model messages and adds them to a Azure Storage Queue.

# TestFunctions

.NET Core 2.1 Project containing Azure function used to process the above queue. It will
then deserialize the Json and send the messages to to inteded recipients via email.