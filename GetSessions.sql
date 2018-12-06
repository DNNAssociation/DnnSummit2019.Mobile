select 
    ee.EntityID,
    eas.Name Entity,
    title.Value Title,
    description.Value Description,
	category.Value Category,
	videoLink.Value VideoLink,
	timeslot.Value TimeSlot,
	day.Value Day,
	abstract.Value Abstract,
	room.Value Room,
	sName.Value SpeakerName,
	sTwitter.Value SpeakerTwitter,
	sBio.Value SpeakerBio,
	sPhoto.Value SpeakerPhoto
    from ToSIC_EAV_Entities ee
    join ToSIC_EAV_AttributeSets eas on ee.AttributeSetID = eas.AttributeSetID
    join 
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Title'
    ) title on title.EntityID = ee.EntityID
    join 
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Description'
    ) description on description.EntityID = ee.EntityID
	join 
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Category'
    ) category on category.EntityID = ee.EntityID
	join 
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'VideoLink'
    ) videoLink on videoLink.EntityID = ee.EntityID
	join 
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'TimeSlot'
    ) timeslot on timeslot.EntityID = ee.EntityID
	join 
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Day'
    ) day on day.EntityID = ee.EntityID
	join 
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Abstract'
    ) abstract on abstract.EntityID = ee.EntityID
	join 
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Room'
    ) room on room.EntityID = ee.EntityID
	join ToSIC_EAV_EntityRelationships relationships on relationships.ParentEntityId = ee.EntityID
	join
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Name'
    ) sName on sName.EntityID = relationships.ChildEntityID
	join
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Twitter'
    ) sTwitter on sTwitter.EntityID = relationships.ChildEntityID
	join
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Bio'
    ) sBio on sBio.EntityID = relationships.ChildEntityID
	join
    (
        select 
            ev.Value,
            ev.EntityID
        from ToSIC_EAV_Values ev
        join ToSIC_EAV_Attributes ea on ev.AttributeID = ea.AttributeID    
        where ea.StaticName = 'Photo'
    ) sPhoto on sPhoto.EntityID = relationships.ChildEntityID	
where eas.Name = 'Sessions'
